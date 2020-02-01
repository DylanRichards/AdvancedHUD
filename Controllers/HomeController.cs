using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdvancedHUD.Models;

namespace AdvancedHUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public static HUD mHUD = new HUD();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Display()
        {
            return View(mHUD);
        }

        [HttpPost]
        public RedirectToActionResult DashboardClicked(string car, string phone)
        {
            Notification notification = new Notification();

            if (!string.IsNullOrEmpty(car))
            {
                switch (car)
                {
                    case "leftcar":
                        notification.content = "There is a car in the Left Lane";
                        break;
                    case "rightcar":
                        notification.content = "There is a car in the Right Lane";
                        break;
                }
            } else if (!string.IsNullOrEmpty(phone))
            {
                switch (phone)
                {
                    case "tweet":
                        notification.content = "@DylanRichards81 published new Tweet";
                        break;
                    case "sms":
                        notification.content = "New Text message from Dylan Richards";
                        break;
                }
            }

            mHUD.AddNotification(notification);

            return RedirectToAction("Display");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
