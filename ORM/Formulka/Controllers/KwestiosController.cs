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
using Formulka.Service;
using Formulka.Repository;

namespace Formulka.Controllers
{
    public class KwestiosController : Controller
    {

        private EmailService _emailService;
        private ContactFormRepository _contactRepository;

        public KwestiosController()
        {
            _emailService = new EmailService();
            _contactRepository = new ContactFormRepository();
        }

        // GET: Kwestios
        public ActionResult Index()
        {
            return View(_contactRepository.GetWhere(x => x.ID>0)); //Get all recods that have IDs
        }

        // GET: Kwestios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kwestio kwestio = _contactRepository.GetWhere(x => x.ID == id.Value).FirstOrDefault();
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
            

            if (ModelState.IsValid)
            {
                _contactRepository.Create(kwestio);
                //db.Kwestionariusze.Add(kwestio);
                //db.SaveChanges();
                var message = _emailService.CreateMailMessage(kwestio);
                _emailService.SendEMail(message);


                return RedirectToAction("Index");
            }

            return View(kwestio);
        }

        // GET: Kwestios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Kwestio kwestio = _contactRepository.GetWhere(x => x.ID == id.Value).FirstOrDefault();
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
                _contactRepository.Update(kwestio);

                //db.Entry(kwestio).State = EntityState.Modified;
                //db.SaveChanges();
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
            Kwestio kwestio = _contactRepository.GetWhere(x => x.ID == id.Value).FirstOrDefault();
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
            Kwestio kwestio = _contactRepository.GetWhere(x => x.ID == id).FirstOrDefault();
            _contactRepository.Delete(kwestio);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
