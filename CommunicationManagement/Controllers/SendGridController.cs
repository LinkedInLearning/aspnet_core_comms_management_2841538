using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunicationManagement.Data;
using CommunicationManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendGridController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SendGridController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("webhook")]
        public IActionResult WebHook(List<SendGridEvents> data)
        {
            var debug = data;
            foreach (var _event in data)
            {
                var dbEmail = _context.Emails.FirstOrDefault(n => _event.sg_message_id.StartsWith(n.SendGridKey));

                if(dbEmail != null)
                {
                    dbEmail.Status = _event.@event;
                    _context.SaveChanges();
                }
            }
            return Ok(debug);
        }
    }
}
