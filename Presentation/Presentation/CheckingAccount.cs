using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class CheckingAccount : Accounts
    {
        decimal balance = 100;

        public decimal Balance { get; set; }

        public CheckingAccount()
        {
            Balance = balance;
        }

        public void Deposit()
        {
            Console.WriteLine("Make a deposit");
        }

        public void Withdraw()
        {
            Console.WriteLine("Take out some money!");
        }

        public void FileWriter()
        {
            Console.WriteLine("write that file");
        }
    }
}
