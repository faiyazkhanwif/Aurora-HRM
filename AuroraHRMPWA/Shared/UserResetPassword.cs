using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class UserResetPassword
    {
        [Required(ErrorMessage = "Invalid email."), EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(22, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password", ErrorMessage = "Passwords do no match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required(ErrorMessage = "Invalid token.")]
        public string Token { get; set; }
    }
}
