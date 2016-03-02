using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
{
    class Clients
    {
        private string name = "Sam Winchester";
        private List<string> transactions = new List<string>();
        private uint accountNum = GetAcctNumber();
        private string allAccountsSummary = "AllAccountsSummary.txt";5

        public string AccountHolder { get; set; }
        public List<string> TransactionHistory { get; set; }
        public static uint AccountNum { get; set; }

        public Clients ()
        {
            AccountHolder = name;
            TransactionHistory = transactions;
            AccountNum = accountNum;
        }

        public static uint GetAcctNumber () //gets a random 6 digit number for the account number
        {
            Random random = new Random();

            uint acctNum = (uint)random.Next(100000, 1000000);

            return acctNum;
        }

        public void PrintClientInfo() //prints the client's info to the console
        {
            Console.WriteLine("Account Holder: " + this.AccountHolder);
        }
    }
}
