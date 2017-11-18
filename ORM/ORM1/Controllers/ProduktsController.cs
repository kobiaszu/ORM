using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORM1.Models;

namespace ORM1.Controllers
{
    public class ProduktsController : Controller
    {
        private ZakupyContext db = new ZakupyContext();

        // GET: Produkts
        public ActionResult Index()
        {
            return View(db.Zakupy.ToList());
        }

        // GET: Produkts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Zakupy.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // GET: Produkts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produkts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                DateTime thisDay = DateTime.UtcNow;
                produkt.Data = thisDay;
                produkt.LastModification = thisDay;

                db.Zakupy.Add(produkt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produkt);
        }

        // GET: Produkts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Zakupy.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                produkt.LastModification = DateTime.UtcNow;

                db.Entry(produkt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produkt);
        }

        // GET: Produkts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produkt produkt = db.Zakupy.Find(id);
            if (produkt == null)
            {
                return HttpNotFound();
            }
            return View(produkt);
        }

        // POST: Produkts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produkt produkt = db.Zakupy.Find(id);
            db.Zakupy.Remove(produkt);
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
