using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
=======
using System.Threading.Tasks;
>>>>>>> 2d846b8ac94a8c76abb3979718a9689a1d6de037
using Microsoft.AspNetCore.Mvc;

namespace KYC.web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
