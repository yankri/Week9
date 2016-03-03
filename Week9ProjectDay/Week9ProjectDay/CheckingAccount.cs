using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class CheckingAccount : Accounts
    {
        List<string> checkingTransactions = new List<string>();
        string filename;
        decimal checkingBalance = 1500;
        string cAcctNum = Clients.AcctNum + "-00";

        public List<string> CheckingTransactions { get; set; }
        public string Filename { get; set; }
        public decimal CheckingBalance { get; set; }
        public string CAcctNum { get; set; }

        public CheckingAccount()
        {
            CheckingTransactions = checkingTransactions;
            filename = this.CheckingFile + ".txt";
            Filename = filename;
            CheckingBalance = checkingBalance;
            CAcctNum = cAcctNum;
        }

        public string CADepositLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tChecking Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void CADeposit(List<string> AllAccountsTransactions) //this method completes the deposit transaction, saving the information to a list. 
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

                    string file = CADepositLineMaker(amount, totalToPrint);

                    CheckingTransactions.Add(file);
                    AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been deposited in your checking account. \nNew balance: $" + CheckingBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }


        public string CAWithdrawLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tChecking Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void CAWithdraw(List<string> AllAccountsTransactions) //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter the amount you want to withdraw: ");
                Console.WriteLine("\nAvailable funds: $" + CheckingBalance);
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    CheckingBalance = CheckingBalance - amount;
                    decimal totalToPrint = CheckingBalance;

                    string file = CAWithdrawLineMaker(amount, totalToPrint);

                    CheckingTransactions.Add(file);
                    AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been withdrawn from your checking account. \nNew balance: $" + CheckingBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string CheckingAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.CAcctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = CheckingAcctFileHeader();

            StreamWriter writer = new StreamWriter(Filename);
            using (writer)
            {
                writer.WriteLine(header);

                if (CheckingTransactions.Count > 0)
                {
                    foreach (string line in CheckingTransactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
