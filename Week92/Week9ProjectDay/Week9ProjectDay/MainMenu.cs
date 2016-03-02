using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class MainMenu
    {
        public void PrintMenu() //this method prints the menu
        {
            Console.Title = "*******BANKING SYSTEM*******";

            Console.WriteLine(Console.Title + "\n\n");
            Console.WriteLine("Enter a number to select an option: \n");
            List<string> menu = new List<string>() { "1 - View Client Information", "2 - View Account Balance", "3 - Deposit Funds", "4 - Withdraw Funds", "5 - Exit" };

            foreach (string option in menu)
            {
                Console.WriteLine(option);
            }
        }

        public void PrintClientInfo(Clients client, ReserveAccount RA, SavingsAccount SA)
        {
            client.PrintClientInfo();
            Console.WriteLine("Checking Account Number: " + CheckingAccount.CAcctNum);
            Console.WriteLine("Savings Account Number: " + SA.SavingsAcctNum);
            Console.WriteLine("Reserve Account Number: " + RA.ReserveAcctNum);
            Console.ReadKey();
        }


        public void PrintBalancesMenu()
        {
            List<string> balances = new List<string>() { "A - Checking Account Balance", "B - Savings Account Balance", "C - Reserve Account Balance", "D - All Accounts" };
            Console.Clear();
            Console.WriteLine("Enter a number to select an option: ");

            foreach (string option in balances)
            {
                Console.WriteLine(option);
            }
        }

        public void Menu() //this method runs the program
        {
            bool close = false;
            Clients client = new Clients();
            Accounts account = new Accounts();
            CheckingAccount CA = new CheckingAccount();
            SavingsAccount SA = new SavingsAccount();
            ReserveAccount RA = new ReserveAccount();

            while (close == false)
            {
                Console.Clear();
                PrintMenu();

                int choice;
                string menuChoice = Console.ReadLine();

                if (int.TryParse(menuChoice, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            //view client info
                            PrintClientInfo(client, CA, RA, SA);
                            break;
                        case 2:
                            //view acct balance
                            BalancesMenu(RA, CA, SA, client); //takes arguments of class objects
                            break;
                        case 3:
                            //deposit

                            break;
                        case 4:
                            //withdraw
                            break;
                        case 5:
                            Console.WriteLine("\nQuitting...");
                            close = true;
                            break;
                        default:
                            continue;
                    }
                }
                else
                {
                    continue;
                }
            }

        }
    }
}
