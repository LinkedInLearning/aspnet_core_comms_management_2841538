﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunicationManagement.Data.ViewModels
{
    public class ComposeEmailVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
