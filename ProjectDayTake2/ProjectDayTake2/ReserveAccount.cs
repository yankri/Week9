using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    class ReserveAccount : Accounts
    {
        decimal balance = 500;
        string filename = "ReserveAccount.txt";
        string acctNum = Clients.AcctNum + "-01R";

        public new string AcctNum { get; set; }
        public string  RFileName { get; set; }

        public ReserveAccount ()
        {
            this.Balance = balance;
            RFileName = filename;
            AcctNum = acctNum;
        }

    }
}
