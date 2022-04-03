using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class EmployeeExperience
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }
        public int YearsServed { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
