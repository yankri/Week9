using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
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

        public void PrintBalancesMenu ()
        {
            List<string> balances = new List<string>() { "A - Checking Account Balance", "B - Savings Account Balance", "C - Reserve Account Balance", "D - All Accounts" };
            Console.Clear();
            Console.WriteLine("Enter a number to select an option: ");
            
            foreach (string option in balances)
            {
                Console.WriteLine(option);
            }
        }

        public void BalancesMenu(ReserveAccount RA, CheckingAccount CA, SavingsAccount SA, Clients client)
        {
            Console.Clear();
            PrintBalancesMenu();
            string input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "A":
                    Console.WriteLine("Checking Account: " + CA.CheckingAcctNum);
                    Console.WriteLine("Current Balance: $" + CA.CheckingBalance);
                    Console.ReadKey();
                    break;
                case "B":
                    Console.WriteLine("Savings Account: " + SA.SavingsAcctNum);
                    Console.WriteLine("Current Balance: $" + SA.SavingsBalance);
                    Console.ReadKey();
                    break;
                case "C":
                    Console.WriteLine("Reserve Account: " + RA.ReserveAcctNum);
                    Console.WriteLine("Current Balance: $" + RA.ReserveBalance);
                    Console.ReadKey();
                    break;
                case "D":
                default:
                    client.PrintClientInfo();
                    Console.WriteLine("Current Balance of All Accounts: $" + (CA.CheckingBalance + RA.ReserveBalance + SA.SavingsBalance));
                    Console.ReadKey();
                    break;
            }
        }

        public void PrintClientInfo(Clients client, CheckingAccount CA, ReserveAccount RA, SavingsAccount SA)
        {
            client.PrintClientInfo();
            Console.WriteLine("Checking Account Number: " + CA.CheckingAcctNum);
            Console.WriteLine("Savings Account Number: " + SA.SavingsAcctNum);
            Console.WriteLine("Reserve Account Number: " + RA.ReserveAcctNum);
            Console.ReadKey();
        }

        public void DepositMenu(ReserveAccount RA, CheckingAccount CA, SavingsAccount SA, Clients client)
        {
            while (true)
            {
                List<string> accounts = new List<string>() { "A - Checking Account", "B - Savings Account", "C - Reserve Account" };
                Console.WriteLine("Enter the account in which you want to make a deposit: ");
                foreach (string option in accounts)
                {
                    Console.WriteLine(option);
                }
                string input = Console.ReadLine().ToUpper();

                switch (input)
                {
                    case "A":
                        Console.WriteLine("**Checking Account Deposit**");
                        Console.WriteLine("Checking Account Number: " + CA.CheckingAcctNum);
                        break;
                }
            }
        }


        public void Menu() //this method runs the program
        {
            bool close = false;
            Clients client = new Clients();
            Accounts account = new Accounts(client);
            CheckingAccount CA = new CheckingAccount(client);
            SavingsAccount SA = new SavingsAccount(client);
            ReserveAccount RA = new ReserveAccount(client);

            while (close == false)
            {
                Console.Clear();
                PrintMenu();

                int choice;
                string menuChoice = Console.ReadLine();

                if (int.TryParse(menuChoice, out choice))
                {
                    switch(choice)
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

            account.FileWriter(client.TransactionHistory); //file is written when the program closes
        }
    }
}
