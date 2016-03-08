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
    public class DocumentRulesController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/DocumentRules
        public ActionResult Index()
        {
            var documentRules = db.DocumentRules.Include(d => d.DocumentType);
            return View(documentRules.ToList());
        }

        // GET: Admin/DocumentRules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRule documentRule = db.DocumentRules.Find(id);
            if (documentRule == null)
            {
                return HttpNotFound();
            }
            return View(documentRule);
        }

        // GET: Admin/DocumentRules/Create
        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description");
            return View();
        }

        // POST: Admin/DocumentRules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CIPType,DocumentTypeId,Choice")] DocumentRule documentRule)
        {
            if (ModelState.IsValid)
            {
                db.DocumentRules.Add(documentRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRule.DocumentTypeId);
            return View(documentRule);
        }

        // GET: Admin/DocumentRules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRule documentRule = db.DocumentRules.Find(id);
            if (documentRule == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRule.DocumentTypeId);
            return View(documentRule);
        }

        // POST: Admin/DocumentRules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CIPType,DocumentTypeId,Choice")] DocumentRule documentRule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "Id", "Description", documentRule.DocumentTypeId);
            return View(documentRule);
        }

        // GET: Admin/DocumentRules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DocumentRule documentRule = db.DocumentRules.Find(id);
            if (documentRule == null)
            {
                return HttpNotFound();
            }
            return View(documentRule);
        }

        // POST: Admin/DocumentRules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentRule documentRule = db.DocumentRules.Find(id);
            db.DocumentRules.Remove(documentRule);
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
