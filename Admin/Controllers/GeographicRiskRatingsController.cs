using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KYC.Entities;
using KYC.Web.DataContext;

namespace KYC.Web.Areas.Admin.Controllers
{
    public class GeographicRiskRatingsController : Controller
    {
        private KYCDb db = new KYCDb();

        // GET: Admin/GeographicRiskRatings
        public async Task<ActionResult> Index()
        {
            return View(await db.GeographicRiskRatings.ToListAsync());
        }

        // GET: Admin/GeographicRiskRatings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeographicRiskRating geographicRiskRating = await db.GeographicRiskRatings.FindAsync(id);
            if (geographicRiskRating == null)
            {
                return HttpNotFound();
            }
            return View(geographicRiskRating);
        }

        // GET: Admin/GeographicRiskRatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/GeographicRiskRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Country,RiskClassUS,RatingDate,RiskScore")] GeographicRiskRating geographicRiskRating)
        {
            if (ModelState.IsValid)
            {
                db.GeographicRiskRatings.Add(geographicRiskRating);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(geographicRiskRating);
        }

        // GET: Admin/GeographicRiskRatings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeographicRiskRating geographicRiskRating = await db.GeographicRiskRatings.FindAsync(id);
            if (geographicRiskRating == null)
            {
                return HttpNotFound();
            }
            return View(geographicRiskRating);
        }

        // POST: Admin/GeographicRiskRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Country,RiskClassUS,RatingDate,RiskScore")] GeographicRiskRating geographicRiskRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geographicRiskRating).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(geographicRiskRating);
        }

        // GET: Admin/GeographicRiskRatings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GeographicRiskRating geographicRiskRating = await db.GeographicRiskRatings.FindAsync(id);
            if (geographicRiskRating == null)
            {
                return HttpNotFound();
            }
            return View(geographicRiskRating);
        }

        // POST: Admin/GeographicRiskRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            GeographicRiskRating geographicRiskRating = await db.GeographicRiskRatings.FindAsync(id);
            db.GeographicRiskRatings.Remove(geographicRiskRating);
            await db.SaveChangesAsync();
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
