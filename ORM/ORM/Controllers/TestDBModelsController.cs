using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ORM.Models;

namespace ORM.Controllers
{
    public class TestDBModelsController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: TestDBModels
        public ActionResult Index()
        {
            return View(db.TestDBModels.ToList());
        }

        // GET: TestDBModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBModel testDBModel = db.TestDBModels.Find(id);
            if (testDBModel == null)
            {
                return HttpNotFound();
            }
            return View(testDBModel);
        }

        // GET: TestDBModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestDBModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Prop")] TestDBModel testDBModel)
        {
            if (ModelState.IsValid)
            {
                db.TestDBModels.Add(testDBModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(testDBModel);
        }

        // GET: TestDBModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBModel testDBModel = db.TestDBModels.Find(id);
            if (testDBModel == null)
            {
                return HttpNotFound();
            }
            return View(testDBModel);
        }

        // POST: TestDBModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Prop")] TestDBModel testDBModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(testDBModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testDBModel);
        }

        // GET: TestDBModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestDBModel testDBModel = db.TestDBModels.Find(id);
            if (testDBModel == null)
            {
                return HttpNotFound();
            }
            return View(testDBModel);
        }

        // POST: TestDBModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TestDBModel testDBModel = db.TestDBModels.Find(id);
            db.TestDBModels.Remove(testDBModel);
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
