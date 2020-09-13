using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommunicationManagement.Data.ViewModels;
using CommunicationManagement.Data.Services;

namespace CommunicationManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _service;

        public HomeController(ILogger<HomeController> logger, IEmailService service)
        {
            _logger = logger;
            _service = service;
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
                _service.SendSingleEmail(composeEmail);
                return View("Success");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
