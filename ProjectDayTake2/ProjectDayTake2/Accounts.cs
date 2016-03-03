using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    class Accounts : Clients, IBankAccounts
    {
        List<string> transactions = new List<string>();

        public decimal Balance { get; set; }
        public List<string> Transactions { get; set; }
        public string Filename { get; set; }
        public string AcctNums { get; set; }

        public Accounts ()
        {
            Transactions = transactions;
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

        public void Deposit() //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter the amount you want to deposit: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    Balance = Balance + amount;
                    decimal totalToPrint = Balance;

                    string file = DepositLineMaker(amount, totalToPrint);

                    Transactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been deposited in your savings account. \nNew balance: $" + Balance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public void Withdraw() //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("\nAvailable funds: $" + Balance);
                Console.WriteLine("Enter the amount you want to withdraw: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    Balance = Balance - amount;
                    decimal totalToPrint = Balance;

                    string file = WithdrawLineMaker(amount, totalToPrint);

                    Transactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been withdrawn from your savings account. \nNew balance: $" + Balance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string WithdrawLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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

        public void FileWriter(string filename)  //writes the files at the end of the program
        {
            string header = FileHeader();

            StreamWriter writer = new StreamWriter(filename);
            using (writer)
            {
                writer.WriteLine(header);

                if (Transactions.Count > 0)
                {
                    foreach (string line in Transactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

        public string FileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Savings Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + AcctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }
    }
}
