using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
{
    class Accounts
    {
        private decimal balance = 100;

        protected Clients client { get; set; }

        public Accounts (Clients client)
        {
            this.client = client;
        }

        public Accounts()
        {}

        public void GetBalance() //writes the current balance to the console
        {
            Console.WriteLine("Current Balance: $" + decimal.Round(CheckingBalance, 2).ToString("0.00"));
            Console.ReadKey();
        }

        //public string GetShortAcctNum(string acctNum) //shortens the account num replaced by asterisks for privacy
        //{
        //    string acctNumAsString = client.AcctNumber.ToString();
        //    StringBuilder sb = new StringBuilder();

        //    for (int i = 0; i < acctNumAsString.Length; i++)
        //    {
        //        if (i < 3)
        //        {
        //            sb.Append("*");
        //        }
        //        else
        //        {
        //            sb.Append(acctNumAsString[i]);
        //        }
        //    }

        //    return sb.ToString();
        //}

        public string AcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + client.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + acctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void Withdraw (List<string> transactionhistory) //this method completes withdrawal transactions and adds the transaction to the list
        {
            decimal amount;
            while (true)
            {
                Console.WriteLine("Enter the amount you want to withdrawal: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    CheckingBalance = CheckingBalance - amount;
                    decimal totalToPrint = CheckingBalance;

                    string header = AcctFileHeader();
                    string file = WithdrawLineMaker(amount, totalToPrint);

                    transactionhistory.Add(file);
                    Console.WriteLine("The amount of " + amount + " has been withdrawn from your account. New balance: $" + CheckingBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string WithdrawLineMaker (decimal amount, decimal totalToPrint) //creates a string containing the transaction information properly formatted for the file
        {
            string amt = amount.ToString("0.00");
            string total = decimal.Round(totalToPrint, 2).ToString("0.00");

            StringBuilder sb = new StringBuilder();

            string time = DateTime.Now.ToString();

            sb.Append(time);
            sb.Append("\t");
            sb.Append(" - ");
            sb.Append("\t");
            sb.Append(amt);
            sb.Append("\t");
            sb.Append(total);
            sb.AppendLine();

            return sb.ToString();
        }

        public void Deposit(List<string> transactionhistory) //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            { 
                Console.WriteLine("Enter the amount you want to deposit: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    CheckingBalance = CheckingBalance + amount;
                    decimal totalToPrint = CheckingBalance;

                    string file = DepositLineMaker(amount, totalToPrint);

                    transactionhistory.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been deposited in your account. New balance : $" + CheckingBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string DepositLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
        {
            string amt = amount.ToString("0.00");
            string total = decimal.Round(totalToPrint, 2).ToString("0.00");

            StringBuilder sb = new StringBuilder();

            string time = DateTime.Now.ToString();

            sb.Append(time);
            sb.Append("\t");
            sb.Append(" + ");
            sb.Append("\t");
            sb.Append(amt);
            sb.Append("\t");
            sb.Append(total);
            sb.AppendLine();

            return sb.ToString();
        }

        public void FileWriter (List<string> transactions, string filename)  //writes the files at the end of the program
        {
            string header = AcctFileHeader();

            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine(header);

                if (transactions.Count > 0)
                {
                    foreach (string line in transactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
