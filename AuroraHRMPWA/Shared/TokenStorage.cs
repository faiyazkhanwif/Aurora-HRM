using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class TokenStorage
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
