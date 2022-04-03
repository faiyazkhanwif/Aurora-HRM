using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public enum QualificatiionName
    {
        Diploma, Bachelors, Masters, PHD
    }

    public enum CompletionStatus
    {
        Complete, Incomplete, Ongoing
    }

    public class Qualification
    {
        public int Id { get; set; }
        public QualificatiionName QualificationName { get; set; }
        public string InstitutionName { get; set; } = string.Empty;
        public string Major { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CompletionStatus CompletionStatus { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
