using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class UserRegister
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(22, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password",ErrorMessage ="Passwords do no match")]
        public string ConfirmPassword { get; set; } = string.Empty;
        [Required,DataType(DataType.Text)]
        public string Name { get; set; } = string.Empty;
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Nationality { get; set; } = string.Empty;
        [Required]
        public string Passport { get; set; } = string.Empty;
        [Required]
        public string MaritalStatus { get; set; } = string.Empty;
        [Required]
        public string Gender { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public int PostCode { get; set; }
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;
        [Required, DataType(DataType.Date)]
        public DateTime BirthDate { get; set; } = DateTime.Now;
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
