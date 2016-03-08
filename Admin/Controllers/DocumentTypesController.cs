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
  public class DocumentTypesController : Controller
  {
    private KYCDb db = new KYCDb();

    // GET: Admin/DocumentTypes
    public ActionResult Index()
    {
      return View(db.DocumentTypes.ToList());
    }

    // GET: Admin/DocumentTypes/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      DocumentType documentType = db.DocumentTypes.Find(id);
      if (documentType == null)
      {
        return HttpNotFound();
      }
      return View(documentType);
    }

    // GET: Admin/DocumentTypes/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Admin/DocumentTypes/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Description")] DocumentType documentType)
    {
      if (ModelState.IsValid)
      {
        db.DocumentTypes.Add(documentType);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(documentType);
    }

    // GET: Admin/DocumentTypes/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      DocumentType documentType = db.DocumentTypes.Find(id);
      if (documentType == null)
      {
        return HttpNotFound();
      }
      return View(documentType);
    }

    // POST: Admin/DocumentTypes/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Description")] DocumentType documentType)
    {
      if (ModelState.IsValid)
      {
        db.Entry(documentType).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(documentType);
    }

    // GET: Admin/DocumentTypes/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      DocumentType documentType = db.DocumentTypes.Find(id);
      if (documentType == null)
      {
        return HttpNotFound();
      }
      return View(documentType);
    }

    // POST: Admin/DocumentTypes/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      DocumentType documentType = db.DocumentTypes.Find(id);
      db.DocumentTypes.Remove(documentType);
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