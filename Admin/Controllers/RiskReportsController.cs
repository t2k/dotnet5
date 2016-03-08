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
using KYC.Web.ViewModels;

namespace KYC.Web.Areas.Admin.Controllers
{
  public class RiskReportsController : Controller
  {
    private KYCDb db = new KYCDb();

    // GET: Admin/RiskReports
    public ActionResult Index()
    {
      return View(db.RiskReports.ToList());
    }

    // GET: Admin/RiskReports/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      RiskReport riskReport = db.RiskReports.Find(id);

      if (riskReport == null)
      {
        return HttpNotFound();
      }
      //ViewBag.RiskItems = riskReport.RiskItems.ToList();
      return View(riskReport);
    }

    // GET: Admin/RiskReports/Create
    public ActionResult Create()
    {

      return View();
    }

    // POST: Admin/RiskReports/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Title,SemVer")] RiskReport riskReport)
    {
      if (ModelState.IsValid)
      {
        db.RiskReports.Add(riskReport);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(riskReport);
    }

    // GET: Admin/RiskReports/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      RiskReport riskReport = db.RiskReports.Find(id);
      if (riskReport == null)
      {
        return HttpNotFound();
      }
      return View(riskReport);
    }

    // POST: Admin/RiskReports/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Title,SemVer")] RiskReport riskReport)
    {
      if (ModelState.IsValid)
      {
        db.Entry(riskReport).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(riskReport);
    }

    // GET: Admin/RiskReports/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      RiskReport riskReport = db.RiskReports.Find(id);

      if (riskReport == null)
      {
        return HttpNotFound();
      }
      return View(riskReport);
    }

    // POST: Admin/RiskReports/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      RiskReport riskReport = db.RiskReports.Find(id);
      db.RiskReports.Remove(riskReport);
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