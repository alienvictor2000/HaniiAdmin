using DoAn2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var query = (from t in db.Transactions
                         select t.Tr_total).Sum();

            var query1 = (from t in db.Transactions
                         where t.Tr_status == false 
                         select t).Count();

            var query2 = (from t in db.Transactions
                          where t.Tr_status == true
                          select t).Count();

            ViewBag.total = query;
            ViewBag.transactions1 = query1;
            ViewBag.transactions2 = query2;

            return View();
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
