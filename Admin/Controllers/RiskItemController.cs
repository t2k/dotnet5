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

namespace KYC.Web.Areas.Admin
{
    public class RiskItemController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/RiskItem
        public ActionResult Index()
        {
            var riskItems = db.RiskItems.Include(r => r.RiskCategory).Include(r => r.RiskClass);
            return View(riskItems.ToList());
        }

        // GET: Admin/RiskItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskItem riskItem = db.RiskItems.Find(id);
            if (riskItem == null)
            {
                return HttpNotFound();
            }
            return View(riskItem);
        }

        // GET: Admin/RiskItem/Create
        public ActionResult Create()
        {
            ViewBag.RiskCategoryId = new SelectList(db.RiskCategories, "Id", "CategoryName");
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification");
            return View();
        }

        // POST: Admin/RiskItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,Score,RiskCategoryId,RiskClassId")] RiskItem riskItem)
        {
            if (ModelState.IsValid)
            {
                db.RiskItems.Add(riskItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RiskCategoryId = new SelectList(db.RiskCategories, "Id", "CategoryName", riskItem.RiskCategoryId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", riskItem.RiskClassId);
            return View(riskItem);
        }

        // GET: Admin/RiskItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskItem riskItem = db.RiskItems.Find(id);
            if (riskItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RiskCategoryId = new SelectList(db.RiskCategories, "Id", "CategoryName", riskItem.RiskCategoryId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", riskItem.RiskClassId);
            return View(riskItem);
        }

        // POST: Admin/RiskItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Score,RiskCategoryId,RiskClassId")] RiskItem riskItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RiskCategoryId = new SelectList(db.RiskCategories, "Id", "CategoryName", riskItem.RiskCategoryId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", riskItem.RiskClassId);
            return View(riskItem);
        }

        // GET: Admin/RiskItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskItem riskItem = db.RiskItems.Find(id);
            if (riskItem == null)
            {
                return HttpNotFound();
            }
            return View(riskItem);
        }

        // POST: Admin/RiskItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskItem riskItem = db.RiskItems.Find(id);
            db.RiskItems.Remove(riskItem);
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
