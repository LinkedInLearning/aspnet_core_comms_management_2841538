using CommunicationManagement.Data.ViewModels;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
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

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@dotnethow.net", "Ervis Trupja");

            var subject = payload.Subject;
            var to = new EmailAddress(payload.Email, $"{payload.FirstName} {payload.LastName}");
            var textContent = payload.Body;
            var htmlContent = $"<strong>{payload.Body}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, textContent, htmlContent);

            var request = client.SendEmailAsync(msg);
            request.Wait();
            var result = request.Result;

            return request;
        }
    }
}
