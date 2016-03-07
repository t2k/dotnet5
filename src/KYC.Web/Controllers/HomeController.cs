using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using KYC.Web.Models.Identity;
using KYC.Web.Models.KYC;
using System;

namespace KYC.Web.Controllers
{

    public class HomeController : Controller
    {
        private KYCContext _db;

        public HomeController(KYCContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RIIndex()
        {
            List<RiskItem> items;

            try
            {
                items = _db.RiskItems.Include(r => r.RiskCategory).Include(r => r.RiskClass).ToList();
            }
            catch (System.Exception)
            {
                items = new List<RiskItem>();
            }

            Console.WriteLine(@"Count of RiskItems{items.Count}");
            return View(items);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
