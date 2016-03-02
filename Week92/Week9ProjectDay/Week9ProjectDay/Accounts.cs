using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class Accounts
    {
        string checkingFile = "Checking Account Summary";
        string savingsFile = "Savings Account Summary";
        string reserveFile = "Reserve Account Summary";
        decimal totalBalance;

        public string CheckingFile { get; set; }
        public string SavingsFile { get; set; }
        public string ReserveFile { get; set; }
        public decimal TotalBalance { get; set; }

        public Accounts ()
        {
            CheckingFile = checkingFile;
            SavingsFile = savingsFile;
            ReserveFile = reserveFile;
            TotalBalance = totalBalance;
        }

        

    }
}
