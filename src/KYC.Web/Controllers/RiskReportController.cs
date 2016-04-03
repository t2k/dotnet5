using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System.Linq;
using Microsoft.Data.Entity;
using KYC.Web.Models.KYC;
using System.Collections.Generic;
using KYC.Web.ViewModels.Risk;
using static System.Console;

namespace KYC.Web.Controllers
{

    public class RiskReportController : Controller
    {
        private KYCContext _db;

        public RiskReportController(KYCContext db) { _db = db; }

        // GET: Admin/RiskReports
        public IActionResult Index()
        {
            _db.RiskReports.ToList().ForEach(i => WriteLine($"Title: {i.Title}  Version {i.SemVer}"));
            return View(_db.RiskReports.Include(i => i.RiskItems).Include(i => i.RiskReportItems).ToList());
        }


        // GET: Admin/RiskReports/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskReportViewModel vm = new RiskReportViewModel();
            
            vm.riskReport = _db.RiskReports.Include(i => i.RiskItems).Where(i => i.RiskReportId == id).Single();
            vm.reportClasses = _db.RiskClasses.ToList();
            vm.reportCategories = _db.RiskCategories.ToList();
            //riskReport.RiskItems.ForEach(r=> WriteLine($"RiskItems: {r.Id} {r.Description} {r.RiskClass.Classification} {r.RiskCategory.CategoryName}"));

            if (vm.riskReport == null)
            {
                return HttpNotFound();
            }

            return View(vm.riskReport);
        }

        // GET: Admin/RiskReports/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Admin/RiskReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,SemVer")] RiskReport riskReport)
        {
            if (ModelState.IsValid)
            {
                _db.RiskReports.Add(riskReport);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskReport);
        }

        // GET: Admin/RiskReports/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskReport riskReport = _db.RiskReports.SingleOrDefault(i => i.RiskReportId == id);
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
        public IActionResult Edit([Bind("Id,Title,SemVer")] RiskReport riskReport)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(riskReport).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskReport);
        }

        // GET: Admin/RiskReports/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(401);
            }
            RiskReport riskReport = _db.RiskReports.SingleOrDefault(i => i.RiskReportId == id);

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
            RiskReport riskReport = _db.RiskReports.SingleOrDefault(i => i.RiskReportId == id);
            _db.RiskReports.Remove(riskReport);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}