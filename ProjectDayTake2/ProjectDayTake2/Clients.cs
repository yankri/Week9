using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    class Clients
    {
        string name = "Sam Winchester";
        string acctNum = GetAcctNumber().ToString();

        public static string AccountHolder { get; set; }
        public static string AcctNum { get; set; }

        public Clients()
        {
            AccountHolder = name;
            AcctNum = acctNum;
        }

        public static uint GetAcctNumber() //gets a random 6 digit number for the account number
        {
            Random random = new Random();

            uint acctNum = (uint)random.Next(100000, 1000000);

            return acctNum;
        }

        public void PrintClientInfo() //prints the client's info to the console
        {
            Console.WriteLine("Account Holder: " + AccountHolder);
        }
    }
}
