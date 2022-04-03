using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraHRMPWA.Shared
{
    public enum Currency
    {
        MYR, SGD, USD, CAD, INR, BDT
    }
    public enum AccountType
    {
        Savings, Current
    }

    public class BankAccount
    {
        public int Id { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string AccountNumber { get; set; } = string.Empty;
        public AccountType AccountType { get; set; }
        public Currency Currency { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
