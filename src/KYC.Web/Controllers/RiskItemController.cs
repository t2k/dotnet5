using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;
using Microsoft.Data.Entity;
using KYC.Web.Models.KYC;
using System.Collections.Generic;

namespace KYC.Web.Controllers
{
    public class RiskItemController : Controller
    {
        private KYCContext _db;

        public RiskItemController(KYCContext db)
        {
            _db=db;
        }
        
        // GET: Admin/RiskItem
        public IActionResult Index()
        {
            
            var riskItems = _db.RiskItems.Include(r => r.RiskCategory).Include(r => r.RiskClass);
            
            return View(riskItems.ToList());
            
            
        }

        // GET: Admin/RiskItem/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskItem RiskItem = _db.RiskItems.SingleOrDefault(i=>i.Id==id);
            if (RiskItem == null)
            {
                return HttpNotFound();
            }
            return View(RiskItem);
        }

        // GET: Admin/RiskItem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/RiskItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CategoryName,Ordinal")] RiskItem RiskItem)
        {
            if (ModelState.IsValid)
            {
                _db.RiskItems.Add(RiskItem);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(RiskItem);
        }

        // GET: Admin/RiskItem/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskItem riskItem = _db.RiskItems.SingleOrDefault(i=>i.Id==id);
            if (riskItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.RiskCategoryId = new SelectList(_db.RiskCategories, "Id", "CategoryName", riskItem.RiskCategoryId);
            ViewBag.RiskClassId = new SelectList(_db.RiskClasses, "Id", "Classification", riskItem.RiskClassId);
            return View(riskItem);
        }

        // POST: Admin/RiskItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RiskItem riskItem)
        {
            System.Console.WriteLine($"Model State: {ModelState.IsValid} RiskItem: {riskItem.Description}");
            
            if (ModelState.IsValid)
            {
                _db.Entry(riskItem).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Admin/RiskItem/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskItem RiskItem = _db.RiskItems.SingleOrDefault(i=>i.Id==id);
            if (RiskItem == null)
            {
                return HttpNotFound();
            }
            return View(RiskItem);
        }

        // POST: Admin/RiskItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RiskItem riskItem = _db.RiskItems.SingleOrDefault(i=>i.Id==id);
            _db.RiskItems.Remove(riskItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}
