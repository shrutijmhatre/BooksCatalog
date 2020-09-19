using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookCatalogNew.Models;

namespace BookCatalogNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Description()
        {
        
            return View();
        }

        public IActionResult HarryPotter()
        {

            return View();
        }

        public IActionResult AThousandSplendidSuns()
        {

            return View();
        }

        public IActionResult AngelsAndDemons()
        {

            return View();
        }

        public IActionResult OliverTwist()
        {

            return View();
        }

        public IActionResult TheAlchemist()
        {

            return View();
        }

        public IActionResult LittleWomen()
        {

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
