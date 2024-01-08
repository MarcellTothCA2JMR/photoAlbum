using KepRendszerezo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KepRendszerezo.Controllers
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
            ViewData["exists"] = bool.Parse(HttpContext.Session.GetString("UsrExists"));

            mydata db = new mydata();
            List<string> Locs = ProcedureHelper.GivaBackLocation();
            Dictionary<int, int> FoldersPicNumbers = ProcedureHelper.ChartDataCollector();

            ViewBag.DataB = db;
            ViewBag.FiltLocs = Locs;
            ViewBag.PictDict = FoldersPicNumbers;

            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("UsrExists", "false");
            return View();
        }

        public IActionResult AfterLogin(User user)
        {
            mydata db = new mydata();
            bool userExists = false;
            foreach (User usr in db.Users)
            {
                if (usr.Username == user.Username && usr.Password == user.Password)
                {
                    HttpContext.Session.SetString("UsrExists", "true");
                    userExists = true;
                    user = usr;
                    break;
                }
            }
            ViewData["exists"] = userExists;
            return View(user);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
