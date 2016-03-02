using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
{
    class ReserveAccount : Accounts
    {
        decimal reserveBalance = 100;
        string reserveAcctNum = Clients.AccountNum.ToString() + "-01R";
        List<string> reserveTransactions = new List<string>();
        string reserveFilename = "ReserveAccountSummary.txt";

        public decimal ReserveBalance { get; set; }
        public string ReserveAcctNum { get; set; }
        public List<string> ReserveTransactions { get; set; }
        public string ReserveFilename { get; set; }


        public ReserveAccount(Clients client)
        {
            ReserveBalance = reserveBalance;
            ReserveAcctNum = reserveAcctNum;
            this.client = client;
            ReserveTransactions = reserveTransactions;
            ReserveFilename = reserveFilename;
        }




    }
}
