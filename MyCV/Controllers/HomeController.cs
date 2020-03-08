using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCV.Models;

namespace MyCV.Controllers
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
            var testCV = GetCV();
            return View(testCV);
        }

        private CurriculumVitae GetCV()
        {
            var cv = new CurriculumVitae();
            cv.ShortResume = "Nyuddannet datalog med en stor passion for softwareudvikling, der arbejder selvstændigt og struktureret. Jeg drives af et konstant ønske om hele tiden at blive bedre og lære noget nyt. Jeg lægger vægt på et godt samarbejde og et godt arbejdsmiljø.";
            ApplicableCompany company = new ApplicableCompany();
            company.Name = "IT-Minds";
            cv.ApplicableCompany = company;
            return cv;
        }



        public IActionResult Privacy()
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
