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
    public class SAPBPStatusController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPBPStatus
        public ActionResult Index()
        {
            return View(db.BPStatuses.OrderBy(i=>i.Description).ToList());
        }

        // GET: Admin/SAPBPStatus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPBPStatus sAPBPStatus = db.BPStatuses.Find(id);
            if (sAPBPStatus == null)
            {
                return HttpNotFound();
            }
            return View(sAPBPStatus);
        }

        // GET: Admin/SAPBPStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPBPStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] SAPBPStatus sAPBPStatus)
        {
            if (ModelState.IsValid)
            {
                db.BPStatuses.Add(sAPBPStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPBPStatus);
        }

        // GET: Admin/SAPBPStatus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPBPStatus sAPBPStatus = db.BPStatuses.Find(id);
            if (sAPBPStatus == null)
            {
                return HttpNotFound();
            }
            return View(sAPBPStatus);
        }

        // POST: Admin/SAPBPStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] SAPBPStatus sAPBPStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPBPStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPBPStatus);
        }

        // GET: Admin/SAPBPStatus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPBPStatus sAPBPStatus = db.BPStatuses.Find(id);
            if (sAPBPStatus == null)
            {
                return HttpNotFound();
            }
            return View(sAPBPStatus);
        }

        // POST: Admin/SAPBPStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPBPStatus sAPBPStatus = db.BPStatuses.Find(id);
            db.BPStatuses.Remove(sAPBPStatus);
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
