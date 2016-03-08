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
    public class SAPLegalEntitiesController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPLegalEntities
        public ActionResult Index()
        {
            return View(db.LegalEntities.OrderBy(i=>i.Description).ToList());
        }

        // GET: Admin/SAPLegalEntities/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalEntity sAPLegalEntity = db.LegalEntities.Find(id);
            if (sAPLegalEntity == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalEntity);
        }

        // GET: Admin/SAPLegalEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPLegalEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] SAPLegalEntity sAPLegalEntity)
        {
            if (ModelState.IsValid)
            {
                db.LegalEntities.Add(sAPLegalEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPLegalEntity);
        }

        // GET: Admin/SAPLegalEntities/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalEntity sAPLegalEntity = db.LegalEntities.Find(id);
            if (sAPLegalEntity == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalEntity);
        }

        // POST: Admin/SAPLegalEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description")] SAPLegalEntity sAPLegalEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPLegalEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPLegalEntity);
        }

        // GET: Admin/SAPLegalEntities/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalEntity sAPLegalEntity = db.LegalEntities.Find(id);
            if (sAPLegalEntity == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalEntity);
        }

        // POST: Admin/SAPLegalEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPLegalEntity sAPLegalEntity = db.LegalEntities.Find(id);
            db.LegalEntities.Remove(sAPLegalEntity);
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
