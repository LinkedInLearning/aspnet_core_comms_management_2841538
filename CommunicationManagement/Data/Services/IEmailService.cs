using CommunicationManagement.Data.ViewModels;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicationManagement.Data.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailVM payload);
        Task<Response> SendMultipleEmails();
    }
}
