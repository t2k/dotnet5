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
    public class SAPLegalFormsController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPLegalForms
        public ActionResult Index()
        {
            return View(db.LegalForms.OrderBy(i=>i.DescriptionEnglish).ToList());
        }

        // GET: Admin/SAPLegalForms/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalForm sAPLegalForm = db.LegalForms.Find(id);
            if (sAPLegalForm == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalForm);
        }

        // GET: Admin/SAPLegalForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPLegalForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DescriptionEnglish,DescriptionGerman")] SAPLegalForm sAPLegalForm)
        {
            if (ModelState.IsValid)
            {
                db.LegalForms.Add(sAPLegalForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPLegalForm);
        }

        // GET: Admin/SAPLegalForms/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalForm sAPLegalForm = db.LegalForms.Find(id);
            if (sAPLegalForm == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalForm);
        }

        // POST: Admin/SAPLegalForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DescriptionEnglish,DescriptionGerman")] SAPLegalForm sAPLegalForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPLegalForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPLegalForm);
        }

        // GET: Admin/SAPLegalForms/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPLegalForm sAPLegalForm = db.LegalForms.Find(id);
            if (sAPLegalForm == null)
            {
                return HttpNotFound();
            }
            return View(sAPLegalForm);
        }

        // POST: Admin/SAPLegalForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPLegalForm sAPLegalForm = db.LegalForms.Find(id);
            db.LegalForms.Remove(sAPLegalForm);
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
