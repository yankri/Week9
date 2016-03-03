using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    class CheckingAccount : Accounts
    {
        decimal balance = 1500;
        string filename = "CheckingAccount.txt";
        string acctNum = Clients.AcctNum + "-00";

        public new string AcctNum { get; set; }
        public string CFilename { get; set; }

        public CheckingAccount()
        {
            this.Balance = balance;
            CFilename = filename;
            AcctNum = acctNum;
        }


    }
}
