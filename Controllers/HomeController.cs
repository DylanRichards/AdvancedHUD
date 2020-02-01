using System;
using System.Diagnostics;
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
            return View(new Dashboard());
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
        public RedirectToActionResult DashboardClicked(Dashboard dashboard, string car, string phone, string clear)
        {
            Notification notification = new Notification();

            if (!string.IsNullOrEmpty(car))
            {
                switch (car)
                {
                    case "leftcarin":
                        mHUD.alerts[Constants.LEFT_CAR] = "red";
                        break;
                    case "rightcarin":
                        mHUD.alerts[Constants.RIGHT_CAR] = "red";
                        break;
                    case "leftcarempty":
                        mHUD.alerts[Constants.LEFT_CAR] = "none";
                        break;
                    case "rightcarempty":
                        mHUD.alerts[Constants.RIGHT_CAR] = "none";
                        break;
                    case "lowfuelon":
                        mHUD.alerts[Constants.LOW_FUEL] = "unset";
                        break;
                    case "lowfueloff":
                        mHUD.alerts[Constants.LOW_FUEL] = "none";
                        break;
                }
            } else if (!string.IsNullOrEmpty(phone))
            {
                switch (phone)
                {
                    case "tweet":
                        notification.imagePath = "../images/twitter.png";
                        notification.content = dashboard.Message;
                        break;
                    case "sms":
                        notification.imagePath = "../images/sms.jpg";
                        notification.content = dashboard.Message;
                        break;
                }

                mHUD.AddNotification(notification);
                mHUD.RemoveExtraNotification();
            } else if (!string.IsNullOrEmpty(clear))
            {
                mHUD.ClearNotifications();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
