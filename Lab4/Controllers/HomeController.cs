using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelAgencyContext _context;

        public HomeController(TravelAgencyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context);
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
