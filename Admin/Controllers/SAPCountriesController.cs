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
    public class SAPCountriesController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/SAPCountries
        public ActionResult Index()
        {
            return View(db.SAPCountries.OrderBy(i=> i.Country).ToList());
        }

        // GET: Admin/SAPCountries/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPCountry sAPCountry = db.SAPCountries.Find(id);
            if (sAPCountry == null)
            {
                return HttpNotFound();
            }
            return View(sAPCountry);
        }

        // GET: Admin/SAPCountries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SAPCountries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Country")] SAPCountry sAPCountry)
        {
            if (ModelState.IsValid)
            {
                db.SAPCountries.Add(sAPCountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sAPCountry);
        }

        // GET: Admin/SAPCountries/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPCountry sAPCountry = db.SAPCountries.Find(id);
            if (sAPCountry == null)
            {
                return HttpNotFound();
            }
            return View(sAPCountry);
        }

        // POST: Admin/SAPCountries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Country")] SAPCountry sAPCountry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sAPCountry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sAPCountry);
        }

        // GET: Admin/SAPCountries/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SAPCountry sAPCountry = db.SAPCountries.Find(id);
            if (sAPCountry == null)
            {
                return HttpNotFound();
            }
            return View(sAPCountry);
        }

        // POST: Admin/SAPCountries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SAPCountry sAPCountry = db.SAPCountries.Find(id);
            db.SAPCountries.Remove(sAPCountry);
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
