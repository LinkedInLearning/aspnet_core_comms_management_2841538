using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicationManagement.Models
{
    public class Email
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string SendGridKey { get; set; }
        public string Status { get; set; }
    }
}
