using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API1.ViewModels
{
    public class UserEmailViewModel
    {
        public EmailRecepient Email { get; set; }
        public string Subject { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

    }
    public class EmailRecepient
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
    }
}