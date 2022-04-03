using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public class EmploymentDetail
    {
        public int Id { get; set; }
        public DateTime DateOfHiring { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal BaseSalary { get; set; }
        [Range(0, 24, ErrorMessage = "Notice period has to be between {1} to {2} months.")]
        public int NoticePeriod { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
