using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class ForgotPasswordSendMail
    {
        public string Email { get; set; } = string.Empty;
        public string MailBody { get; set; } = string.Empty;
    }
}
