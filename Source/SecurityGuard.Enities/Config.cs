using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityGuard.Enities
{
    public class Config
    {
        public string SmtpServer { get; set; }
        public string MailgunApiKey { get; set; }
        public string MailgunApiUrl { get; set; }
        public string MailgunDomain { get; set; }
        public string ShowVideo { get; set; }
        public bool EmailTestMode { get; set; }
        public string ForgotPasswordEmailTemplate { get; set; }
        public string ForgotPasswordEmailSubject { get; set; }
    }
}
