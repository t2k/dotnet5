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
    public class SAPSystematicsController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPSystematics
        public ActionResult Index()
        {
            return View(db.Systematics.OrderBy(i=>i.Description).ToList());
        }

        // GET: Admin/SAPSystematics/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPSystematic sAPSystematic = db.Systematics.Find(id);
            if (sAPSystematic == null)
            {
                return HttpNotFound();
            }
            return View(sAPSystematic);
        }

        // GET: Admin/SAPSystematics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPSystematics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] SAPSystematic sAPSystematic)
        {
            if (ModelState.IsValid)
            {
                db.Systematics.Add(sAPSystematic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPSystematic);
        }

        // GET: Admin/SAPSystematics/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPSystematic sAPSystematic = db.Systematics.Find(id);
            if (sAPSystematic == null)
            {
                return HttpNotFound();
            }
            return View(sAPSystematic);
        }

        // POST: Admin/SAPSystematics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] SAPSystematic sAPSystematic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPSystematic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPSystematic);
        }

        // GET: Admin/SAPSystematics/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPSystematic sAPSystematic = db.Systematics.Find(id);
            if (sAPSystematic == null)
            {
                return HttpNotFound();
            }
            return View(sAPSystematic);
        }

        // POST: Admin/SAPSystematics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPSystematic sAPSystematic = db.Systematics.Find(id);
            db.Systematics.Remove(sAPSystematic);
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
