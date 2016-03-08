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
    public class PublicExchangesController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/PublicExchanges
        public ActionResult Index()
        {
            return View(db.PublicExchanges.ToList());
        }

        // GET: Admin/PublicExchanges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicExchange publicExchange = db.PublicExchanges.Find(id);
            if (publicExchange == null)
            {
                return HttpNotFound();
            }
            return View(publicExchange);
        }

        // GET: Admin/PublicExchanges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PublicExchanges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Exchange")] PublicExchange publicExchange)
        {
            if (ModelState.IsValid)
            {
                db.PublicExchanges.Add(publicExchange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicExchange);
        }

        // GET: Admin/PublicExchanges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicExchange publicExchange = db.PublicExchanges.Find(id);
            if (publicExchange == null)
            {
                return HttpNotFound();
            }
            return View(publicExchange);
        }

        // POST: Admin/PublicExchanges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Exchange")] PublicExchange publicExchange)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicExchange).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicExchange);
        }

        // GET: Admin/PublicExchanges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicExchange publicExchange = db.PublicExchanges.Find(id);
            if (publicExchange == null)
            {
                return HttpNotFound();
            }
            return View(publicExchange);
        }

        // POST: Admin/PublicExchanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicExchange publicExchange = db.PublicExchanges.Find(id);
            db.PublicExchanges.Remove(publicExchange);
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
