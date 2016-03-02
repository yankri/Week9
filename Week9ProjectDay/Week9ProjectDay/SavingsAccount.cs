using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class SavingsAccount : Accounts
    {
        List<string> savingsTransactions = new List<string>();
        string filename;
        decimal savingsBalance = 5000;
        string sAcctNum = Clients.AcctNum + "-01";

        public List<string> SavingsTransactions { get; set; }
        public string Filename { get; set; }
        public decimal SavingsBalance { get; set; }
        public string SAcctNum { get; set; }

        public SavingsAccount ()
        {
            SavingsTransactions = savingsTransactions;
            filename = this.SavingsFile + ".txt";
            Filename = filename;
            SavingsBalance = savingsBalance;
            SAcctNum = sAcctNum;
        }

        public string SADepositLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tSavings Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void SADeposit() //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter the amount you want to deposit: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    SavingsBalance = SavingsBalance + amount;
                    decimal totalToPrint = SavingsBalance;

                    string file = SADepositLineMaker(amount, totalToPrint);

                    SavingsTransactions.Add(file);
                    Accounts.AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been deposited in your savings account. \nNew balance: $" + SavingsBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string SAWithdrawLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tSavings Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void SAWithdraw() //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("\nAvailable funds: $" + SavingsBalance);
                Console.WriteLine("Enter the amount you want to withdraw: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    SavingsBalance = SavingsBalance - amount;
                    decimal totalToPrint = SavingsBalance;

                    string file = SAWithdrawLineMaker(amount, totalToPrint);

                    SavingsTransactions.Add(file);
                    Accounts.AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been withdrawn from your savings account. \nNew balance: $" + SavingsBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public string SavingsAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Savings Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.SAcctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = SavingsAcctFileHeader();

            StreamWriter writer = new StreamWriter(Filename);
            using (writer)
            {
                writer.WriteLine(header);

                if (SavingsTransactions.Count > 0)
                {
                    foreach (string line in SavingsTransactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

    }
}
