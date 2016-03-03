using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
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

        public void ClosingImage()
        {
            StreamReader reader = new StreamReader("ClosingImage.txt");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Console.WriteLine(line);
                }
            }
        }

        public void PrintClientInfo(Clients client, string Cnum, string Rnum, string Snum)
        {
            client.PrintClientInfo();
            Console.WriteLine("Checking Account Number: " + Cnum);
            Console.WriteLine("Savings Account Number: " + Snum);
            Console.WriteLine("Reserve Account Number: " + Rnum);
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

        public void BalancesMenu(ReserveAccount RA, CheckingAccount CA, SavingsAccount SA, Clients client)
        {
            Console.Clear();
            PrintBalancesMenu();
            string input = Console.ReadLine().ToUpper();

            switch (input)
            {
                case "A":
                    Console.WriteLine("Checking Account: " + CA.AcctNum);
                    Console.WriteLine("Current Balance: $" + CA.Balance);
                    Console.ReadKey();
                    break;
                case "B":
                    Console.WriteLine("Savings Account: " + SA.AcctNum);
                    Console.WriteLine("Current Balance: $" + SA.Balance);
                    Console.ReadKey();
                    break;
                case "C":
                    Console.WriteLine("Reserve Account: " + RA.AcctNum);
                    Console.WriteLine("Current Balance: $" + RA.Balance);
                    Console.ReadKey();
                    break;
                case "D":
                default:
                    Console.WriteLine();
                    client.PrintClientInfo();
                    Console.WriteLine("\nChecking Account: " + CA.AcctNum);
                    Console.WriteLine("Current Balance: $" + CA.Balance);
                    Console.WriteLine("\nSavings Account: " + SA.AcctNum);
                    Console.WriteLine("Current Balance: $" + SA.Balance);
                    Console.WriteLine("\nReserve Account: " + RA.AcctNum);
                    Console.WriteLine("Current Balance: $" + RA.Balance);
                    Console.WriteLine("\nCurrent Balance of All Accounts: $" + (CA.Balance + RA.Balance + SA.Balance));
                    Console.ReadKey();
                    break;
            }
        }

        public void DepositMenu(ReserveAccount RA, CheckingAccount CA, SavingsAccount SA, Accounts account)
        {
            while (true)
            {
                Console.Clear();
                List<string> accounts = new List<string>() { "A - Checking Account", "B - Savings Account", "C - Reserve Account" };
                Console.WriteLine("Enter the account in which you want to make a deposit: ");
                foreach (string option in accounts)
                {
                    Console.WriteLine(option);
                }
                string input = Console.ReadLine().ToUpper();

                if (input == "quit")
                {
                    return;
                }

                switch (input)
                {
                    case "A":
                        Console.WriteLine("**Checking Account Deposit**");
                        Console.WriteLine("Checking Account Number: " + CA.AcctNum);
                        CA.Deposit();
                        return;
                    case "B":
                        Console.WriteLine("**Savings Account Deposit**");
                        Console.WriteLine("Savings Account Number: " + SA.AcctNum);
                        SA.Deposit();
                        return;
                    case "C":
                        Console.WriteLine("**Reserve Account Deposit**");
                        Console.WriteLine("Reserve Account Number: " + RA.AcctNum);
                        RA.Deposit();
                        return;
                    default:
                        Console.WriteLine("Please select an account or enter quit to return to the main menu.");
                        continue;
                }
            }
        }

        public void WithdrawMenu(ReserveAccount RA, CheckingAccount CA, SavingsAccount SA, Accounts account)
        {
            while (true)
            {
                Console.Clear();
                List<string> accounts = new List<string>() { "A - Checking Account", "B - Savings Account", "C - Reserve Account" };
                Console.WriteLine("Enter the account from which you want to make a withdrawal: ");
                foreach (string option in accounts)
                {
                    Console.WriteLine(option);
                }
                string input = Console.ReadLine().ToUpper();

                if (input == "quit")
                {
                    return;
                }

                switch (input)
                {
                    case "A":
                        Console.WriteLine("**Checking Account Withdrawal**");
                        Console.WriteLine("Checking Account Number: " + CA.AcctNum);
                        CA.Withdraw();
                        return;
                    case "B":
                        Console.WriteLine("**Savings Account Withdrawal**");
                        Console.WriteLine("Savings Account Number: " + SA.AcctNum);
                        SA.Withdraw();
                        return;
                    case "C":
                        Console.WriteLine("**Reserve Account Withdrawal**");
                        Console.WriteLine("Reserve Account Number: " + RA.AcctNum);
                        RA.Withdraw();
                        return;
                    default:
                        Console.WriteLine("Please select an account or enter quit to return to the main menu.");
                        continue;
                }
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
                            PrintClientInfo(client, CA.AcctNum, RA.AcctNum, SA.AcctNum);
                            break;
                        case 2:
                            //view acct balance
                            BalancesMenu(RA, CA, SA, client);
                            break;
                        case 3:
                            //deposit
                            DepositMenu(RA, CA, SA, account);
                            break;
                        case 4:
                            //withdraw
                            WithdrawMenu(RA, CA, SA, account);
                            break;
                        case 5:
                            Console.Clear();
                            ClosingImage();
                            Console.WriteLine("\nQuitting...");
                            Console.ReadKey();
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

            RA.FileWriter(RA.RFileName);
            SA.FileWriter(SA.SFilename);
            CA.FileWriter(CA.CFilename);
        }
    }
}
