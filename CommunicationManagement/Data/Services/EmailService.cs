using CommunicationManagement.Data.ViewModels;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicationManagement.Data.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task<Response> SendSingleEmail(ComposeEmailVM payload)
        {
            var apiKey = _configuration.GetSection("SendGrid")["ApiKey"];
            return null;
        }
    }
}
