using System;
using System.Threading.Tasks;
using Email.Service.SmtpSetting;

namespace Email.Service.Entity
{
    public class SendEmailEntity
    {
        public string Email { get; set; }
        public string NameEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}