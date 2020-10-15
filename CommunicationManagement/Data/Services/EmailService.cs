using CommunicationManagement.Data.ViewModels;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

            //Attachment
            if(payload.Attachment != null && payload.Attachment.Length > 0)
            {
                var fileContent = "";
                byte[] byteData;
                using (var reader = new StreamReader(payload.Attachment.OpenReadStream()))
                {
                    fileContent = reader.ReadToEnd().ToString();
                    byteData = Encoding.ASCII.GetBytes(fileContent);
                }

                Attachment attachment = new Attachment()
                {
                    Content = Convert.ToBase64String(byteData),
                    Filename = payload.Attachment.FileName,
                    Type = payload.Attachment.ContentType,
                    Disposition = "attachment"
                };
                msg.AddAttachment(attachment);
            }

            var request = client.SendEmailAsync(msg);
            request.Wait();
            var result = request.Result;

            return request;
        }

        public Task<Response> SendMultipleEmails()
        {
            var apiKey = _configuration.GetSection("SendGrid")["ApiKey"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@dotnethow.net", "Ervis Trupja");

            var subject = "Multiple emails";
            var tos = new List<EmailAddress>(){
                new EmailAddress("someemail@email.com", $"First Last - 1"),
                new EmailAddress("sendgrid@devyscope.com", $"Second Second - 2")
            };

            var textContent = "Multiple emails";
            var htmlContent = $"<strong>Multiple emails</strong>";

            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, textContent, htmlContent);

            var request = client.SendEmailAsync(msg);
            request.Wait();
            var result = request.Result;

            return request;
        }
    }
}
