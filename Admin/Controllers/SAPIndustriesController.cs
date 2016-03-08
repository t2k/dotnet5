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
  public class SAPIndustriesController : Controller
  {
    private KYCDb db = new KYCDb();

    // GET: Admin/SAPIndustries
    public ActionResult Index()
    {
      return View(db.SAPIndustries.OrderBy(i => i.Description).ToList());
    }

    // GET: Admin/SAPIndustries/Details/5
    public ActionResult Details(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      SAPIndustry sAPIndustry = db.SAPIndustries.Find(id);
      if (sAPIndustry == null)
      {
        return HttpNotFound();
      }
      return View(sAPIndustry);
    }

    // GET: Admin/SAPIndustries/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Admin/SAPIndustries/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Description")] SAPIndustry sAPIndustry)
    {
      if (ModelState.IsValid)
      {
        db.SAPIndustries.Add(sAPIndustry);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(sAPIndustry);
    }

    // GET: Admin/SAPIndustries/Edit/5
    public ActionResult Edit(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      SAPIndustry sAPIndustry = db.SAPIndustries.Find(id);
      if (sAPIndustry == null)
      {
        return HttpNotFound();
      }
      return View(sAPIndustry);
    }

    // POST: Admin/SAPIndustries/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Description")] SAPIndustry sAPIndustry)
    {
      if (ModelState.IsValid)
      {
        db.Entry(sAPIndustry).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(sAPIndustry);
    }

    // GET: Admin/SAPIndustries/Delete/5
    public ActionResult Delete(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      SAPIndustry sAPIndustry = db.SAPIndustries.Find(id);
      if (sAPIndustry == null)
      {
        return HttpNotFound();
      }
      return View(sAPIndustry);
    }

    // POST: Admin/SAPIndustries/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(string id)
    {
      SAPIndustry sAPIndustry = db.SAPIndustries.Find(id);
      db.SAPIndustries.Remove(sAPIndustry);
      db.SaveChanges();
      return RedirectToAction("Index");
    }


    // async GET: /admin/SAPIndustries/Lookup
    public ActionResult Lookup(string q)
    {
      if (!string.IsNullOrWhiteSpace(q))
      {
        var namesFilter = db.SAPIndustries.Where(c => c.Description.Contains(q)).OrderBy(c => c.Description).Select(c => new { key = c.Id, value = c.Description}).Take(100);
        return Json(namesFilter, JsonRequestBehavior.AllowGet);
      }

      var names = db.SAPIndustries.OrderBy(c => c.Description).Select(c => new {key = c.Id, value = c.Description}).Take(100);
      return Json(names, JsonRequestBehavior.AllowGet);
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