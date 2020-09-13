using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommunicationManagement.Data.ViewModels;
using CommunicationManagement.Data.Services;
using CommunicationManagement.Data;
using System.Linq;

namespace CommunicationManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _service;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, IEmailService service, AppDbContext context)
        {
            _logger = logger;
            _service = service;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var result = _context.Emails.ToList();
            return View(result);
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
                //_service.SendMultipleEmails();
                return View("Success");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
