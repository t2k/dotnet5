using Microsoft.AspNet.Mvc;
using System.Linq;
using Microsoft.Data.Entity;
using KYC.Web.Models.KYC;
using System;

namespace KYC.Web.Controllers
{
    public class RiskCategoryController : Controller
    {
        private KYCContext _db;

        public RiskCategoryController(KYCContext db)
        {
            _db=db;
            
            Console.WriteLine($"controller is constructed with {_db}");
            
        }
        
        // GET: Admin/RiskCategory
        public IActionResult Index()
        {
            Console.WriteLine("Index controller!");
            return View(_db.RiskCategories.ToList());
        }

        // GET: Admin/RiskCategory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskCategory riskCategory = _db.RiskCategories.SingleOrDefault(i=>i.Id==id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RiskCategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryName,Ordinal")] RiskCategory riskCategory)
        {
            if (ModelState.IsValid)
            {
                _db.RiskCategories.Add(riskCategory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskCategory riskCategory = _db.RiskCategories.SingleOrDefault(i=>i.Id==id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // POST: Admin/RiskCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,CategoryName,Ordinal")] RiskCategory riskCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(riskCategory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskCategory);
        }

        // GET: Admin/RiskCategory/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskCategory riskCategory = _db.RiskCategories.SingleOrDefault(i=>i.Id==id);
            if (riskCategory == null)
            {
                return HttpNotFound();
            }
            return View(riskCategory);
        }

        // POST: Admin/RiskCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RiskCategory riskCategory = _db.RiskCategories.SingleOrDefault(i=>i.Id==id);
            _db.RiskCategories.Remove(riskCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
