using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommunicationManagement.Data.ViewModels;

namespace CommunicationManagement.Controllers
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

        public IActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendEmail(ComposeEmailVM composeEmail)
        {
            try
            {
                return View("Success");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
