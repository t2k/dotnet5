using Microsoft.AspNet.Mvc;
using System.Linq;
using Microsoft.Data.Entity;
using KYC.Web.Models.KYC;
using System;

namespace KYC.Web.Controllers
{
    public class RiskClassController : Controller
    {
        private KYCContext _db;

        public RiskClassController(KYCContext db)
        {
            _db=db;
            
            Console.WriteLine($"controller is constructed with {_db}");
            
        }
        
        // GET: Admin/RiskCategory
        public IActionResult Index()
        {

            return View(_db.RiskClasses.ToList());
        }

        // GET: Admin/RiskCategory/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskClass riskClass = _db.RiskClasses.SingleOrDefault(i=>i.Id==id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
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
        public IActionResult Create([Bind("Id,CategoryName,Ordinal")] RiskClass riskClass)
        {
            if (ModelState.IsValid)
            {
                _db.RiskClasses.Add(riskClass);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskClass);
        }

        // GET: Admin/RiskCategory/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskClass riskClass = _db.RiskClasses.SingleOrDefault(i=>i.Id==id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
        }

        // POST: Admin/RiskCategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,CategoryName,Ordinal")] RiskClass riskClass)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(riskClass).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskClass);
        }

        // GET: Admin/RiskCategory/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskClass riskClass = _db.RiskClasses.SingleOrDefault(i=>i.Id==id);
            if (riskClass == null)
            {
                return HttpNotFound();
            }
            return View(riskClass);
        }

        // POST: Admin/RiskCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RiskClass riskClass = _db.RiskClasses.SingleOrDefault(i=>i.Id==id);
            _db.RiskClasses.Remove(riskClass);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
