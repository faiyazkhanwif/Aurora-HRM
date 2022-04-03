using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public enum Relation
    {
        Parent, Spouse, Child
    }
    public class FamilyMember
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Relation Relation { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
