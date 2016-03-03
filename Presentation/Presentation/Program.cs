using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {

            CheckingAccount checking = new CheckingAccount();
            while (true)
            {
                Console.WriteLine("Make a choice: A for deposit, B for withdraw");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "A":
                        checking.Deposit();
                        break;
                    case "B":
                        checking.Withdraw();
                        break;
                    default:
                        continue;

                }
            }
        }
    }
}
