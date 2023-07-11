using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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

    [HttpPost]
        public IActionResult Index(Calculator cal)
        {
            int a, b;
            a = cal.value1;
            b = cal.value2;

            if (cal.calculate == "+")
            {
                cal.result = a + b;
            };

            if (cal.calculate == "-")
            {
                cal.result = a - b;
            };

            if (cal.calculate == "*")
            {
                cal.result = a * b;
            };

            ViewData["result"] = cal.result;
            return View();
        }

        /*public IActionResult Privacy()
        {
            return View();
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Privacy()
        {
            List<user> users = new List<user>();

            using(var db = new DemoContext())
            {
                users = db.Users.ToList();
            }

            ViewBag.users = users;

            return View();
        }

        [HttpPost]
        public IActionResult Privacy(user user)
        {
            using (var db = new DemoContext())
            {
                db.Add(user);
                db.SaveChanges();
            }
            List<user> users = new List<user>();

            using (var db = new DemoContext())
            {
                users = db.Users.ToList();
            }

            ViewBag.users = users;

            return View();
        }
    }
}
