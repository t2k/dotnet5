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
    public class SAPRiskSectorsController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPRiskSectors
        public ActionResult Index()
        {
            return View(db.RiskSectors.ToList());
        }

        // GET: Admin/SAPRiskSectors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPRiskSector sAPRiskSector = db.RiskSectors.Find(id);
            if (sAPRiskSector == null)
            {
                return HttpNotFound();
            }
            return View(sAPRiskSector);
        }

        // GET: Admin/SAPRiskSectors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPRiskSectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SAPRiskSectorId,Description")] SAPRiskSector sAPRiskSector)
        {
            if (ModelState.IsValid)
            {
                db.RiskSectors.Add(sAPRiskSector);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPRiskSector);
        }

        // GET: Admin/SAPRiskSectors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPRiskSector sAPRiskSector = db.RiskSectors.Find(id);
            if (sAPRiskSector == null)
            {
                return HttpNotFound();
            }
            return View(sAPRiskSector);
        }

        // POST: Admin/SAPRiskSectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SAPRiskSectorId,Description")] SAPRiskSector sAPRiskSector)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPRiskSector).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPRiskSector);
        }

        // GET: Admin/SAPRiskSectors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPRiskSector sAPRiskSector = db.RiskSectors.Find(id);
            if (sAPRiskSector == null)
            {
                return HttpNotFound();
            }
            return View(sAPRiskSector);
        }

        // POST: Admin/SAPRiskSectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPRiskSector sAPRiskSector = db.RiskSectors.Find(id);
            db.RiskSectors.Remove(sAPRiskSector);
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
