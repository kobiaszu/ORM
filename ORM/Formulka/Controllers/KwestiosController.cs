using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Formulka.Models;
using System.Net.Mail;

namespace Formulka.Controllers
{
    public class KwestiosController : Controller
    {
        private KwestioDBContext db = new KwestioDBContext();

        // GET: Kwestios
        public ActionResult Index()
        {
            return View(db.Kwestionariusze.ToList());
        }

        // GET: Kwestios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwestio kwestio = db.Kwestionariusze.Find(id);
            if (kwestio == null)
            {
                return HttpNotFound();
            }
            return View(kwestio);
        }

        // GET: Kwestios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kwestios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Email,Subject,Description")] Kwestio kwestio)
        {
            SendEmail(kwestio);

            if (ModelState.IsValid)
            {
                db.Kwestionariusze.Add(kwestio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kwestio);
        }

        private void SendEmail(Kwestio kwestio)
        {
            {
                var smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = true,
                    Credentials =
                    new NetworkCredential("gym550182@gmail.com", "!QAZ2wsx#EDC")
                };

                var BodyMessage = "from " + kwestio.Email.ToString() + ": " + kwestio.Description;

                var mailMessage = new MailMessage
                {
                    Sender = new MailAddress("gym550182@gmail.com"),
                    From = new MailAddress("gym550182@gmail.com"),
                    To = { "kobiaszu@gmail.com" },
                    Subject = kwestio.Subject,
                    Body = BodyMessage,
                    IsBodyHtml = true
                };

                smtpClient.Send(mailMessage);
            }


        }

        // GET: Kwestios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwestio kwestio = db.Kwestionariusze.Find(id);
            if (kwestio == null)
            {
                return HttpNotFound();
            }
            return View(kwestio);
        }

        

        // POST: Kwestios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Email,Subject,Description")] Kwestio kwestio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kwestio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kwestio);
        }

        // GET: Kwestios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwestio kwestio = db.Kwestionariusze.Find(id);
            if (kwestio == null)
            {
                return HttpNotFound();
            }
            return View(kwestio);
        }

        // POST: Kwestios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kwestio kwestio = db.Kwestionariusze.Find(id);
            db.Kwestionariusze.Remove(kwestio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
