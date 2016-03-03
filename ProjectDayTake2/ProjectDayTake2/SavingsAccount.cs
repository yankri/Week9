using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    class SavingsAccount : Accounts
    {
        decimal balance = 5000;
        string filename = "SavingsAccount.txt";
        string acctNum = Clients.AcctNum + "-01";

        public new string AcctNum { get; set; }
        public string SFilename { get; set; }

        public SavingsAccount()
        {
            this.Balance = balance;
            SFilename = filename;
            AcctNum = acctNum;
        }

    }
}
