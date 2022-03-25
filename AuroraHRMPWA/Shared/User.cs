using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int PostCode { get; set; }
        public string State { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Role { get; set; } = string.Empty;


    }
}
