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
    public class RiskCategoryController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/RiskCategory
        public ActionResult Index()
        {
            return View(db.RiskCategories.ToList());
        }

        // GET: Admin/RiskCategory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskCategory riskCategory = db.RiskCategories.Find(id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/RiskCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryName,Ordinal")] RiskCategory riskCategory)
        {
            if (ModelState.IsValid)
            {
                db.RiskCategories.Add(riskCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskCategory riskCategory = db.RiskCategories.Find(id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // POST: Admin/RiskCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryName,Ordinal")] RiskCategory riskCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskCategory riskCategory = db.RiskCategories.Find(id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // POST: Admin/RiskCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskCategory riskCategory = db.RiskCategories.Find(id);
            db.RiskCategories.Remove(riskCategory);
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
