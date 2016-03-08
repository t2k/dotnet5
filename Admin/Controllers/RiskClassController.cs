using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYC.Entities;
using KYC.Web.DataContext;

namespace KYC.Web.Areas.Admin.Controllers
{
    public class RiskClassController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/RiskClass
        public ActionResult Index()
        {
            return View(db.RiskClasses.ToList());
        }

        // GET: Admin/RiskClass/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskClass riskClass = db.RiskClasses.Find(id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
        }

        // GET: Admin/RiskClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RiskClass/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Classification,Ordinal")] RiskClass riskClass)
        {
            if (ModelState.IsValid)
            {
                db.RiskClasses.Add(riskClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskClass);
        }

        // GET: Admin/RiskClass/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskClass riskClass = db.RiskClasses.Find(id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
        }

        // POST: Admin/RiskClass/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Classification,Ordinal")] RiskClass riskClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskClass);
        }

        // GET: Admin/RiskClass/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskClass riskClass = db.RiskClasses.Find(id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
        }

        // POST: Admin/RiskClass/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskClass riskClass = db.RiskClasses.Find(id);
            db.RiskClasses.Remove(riskClass);
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
