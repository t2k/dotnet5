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
    public class DocumentRiskCyclesController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/DocumentRiskCycles
        public ActionResult Index()
        {
            var documentRiskCycles = db.DocumentRiskCycles.Include(d => d.DocumentType).Include(d => d.RiskClass);
            return View(documentRiskCycles.ToList());
        }

        // GET: Admin/DocumentRiskCycles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRiskCycle documentRiskCycle = db.DocumentRiskCycles.Find(id);
            if (documentRiskCycle == null)
            {
                return HttpNotFound();
            }
            return View(documentRiskCycle);
        }

        // GET: Admin/DocumentRiskCycles/Create
        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description");
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification");
            return View();
        }

        // POST: Admin/DocumentRiskCycles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RiskClassId,DocumentTypeId,Cycle")] DocumentRiskCycle documentRiskCycle)
        {
            if (ModelState.IsValid)
            {
                db.DocumentRiskCycles.Add(documentRiskCycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRiskCycle.DocumentTypeId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", documentRiskCycle.RiskClassId);
            return View(documentRiskCycle);
        }

        // GET: Admin/DocumentRiskCycles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRiskCycle documentRiskCycle = db.DocumentRiskCycles.Find(id);
            if (documentRiskCycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRiskCycle.DocumentTypeId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", documentRiskCycle.RiskClassId);
            return View(documentRiskCycle);
        }

        // POST: Admin/DocumentRiskCycles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RiskClassId,DocumentTypeId,Cycle")] DocumentRiskCycle documentRiskCycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentRiskCycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRiskCycle.DocumentTypeId);
            ViewBag.RiskClassId = new SelectList(db.RiskClasses, "Id", "Classification", documentRiskCycle.RiskClassId);
            return View(documentRiskCycle);
        }

        // GET: Admin/DocumentRiskCycles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRiskCycle documentRiskCycle = db.DocumentRiskCycles.Find(id);
            if (documentRiskCycle == null)
            {
                return HttpNotFound();
            }
            return View(documentRiskCycle);
        }

        // POST: Admin/DocumentRiskCycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentRiskCycle documentRiskCycle = db.DocumentRiskCycles.Find(id);
            db.DocumentRiskCycles.Remove(documentRiskCycle);
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
