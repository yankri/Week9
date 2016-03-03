using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class ReserveAccount : Accounts
    {
        List<string> reserveTransactions = new List<string>();
        string filename;
        decimal reserveBalance = 200;
        string rAcctNum = Clients.AcctNum + "-01R";

        public List<string> ReserveTransactions { get; set; }
        public string Filename { get; set; }
        public decimal ReserveBalance { get; set; }
        public string RAcctNum { get; set; }

        public ReserveAccount ()
        {
            ReserveTransactions = reserveTransactions;
            filename = this.ReserveFile + ".txt";
            Filename = filename;
            ReserveBalance = reserveBalance;
            RAcctNum = rAcctNum;
        }

        public string RADepositLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tReserve Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void RADeposit(List<string> AllAccountsTransactions) //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter the amount you want to deposit: ");
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    ReserveBalance = ReserveBalance + amount;
                    decimal totalToPrint = ReserveBalance;

                    string file = RADepositLineMaker(amount, totalToPrint);

                    ReserveTransactions.Add(file);
                    AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been deposited in your reserve account. \nNew balance: $" + ReserveBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        public string RAWithdrawLineMaker(decimal amount, decimal totalToPrint) //creates a string that includes all the deposit transaction information
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
            sb.Append(total + "\tReserve Account");
            sb.AppendLine();

            return sb.ToString();
        }

        public void RAWithdraw(List<string> AllAccountsTransactions) //this method completes the deposit transaction, saving the information to a list. 
        {
            decimal amount;

            while (true)
            {
                Console.WriteLine("Enter the amount you want to withdraw: ");
                Console.WriteLine("\nAvailable funds: $" + ReserveBalance);
                string input = Console.ReadLine();
                bool result = decimal.TryParse(input, out amount);

                if (result == true)
                {
                    ReserveBalance = ReserveBalance - amount;
                    decimal totalToPrint = ReserveBalance;

                    string file = RAWithdrawLineMaker(amount, totalToPrint);

                    ReserveTransactions.Add(file);
                    AllAccountsTransactions.Add(file);
                    Console.WriteLine("The amount of $" + amount + " has been withdrawn from your reserve account. \nNew balance: $" + ReserveBalance);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        public string ReserveAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Reserve Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.RAcctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = ReserveAcctFileHeader();
            
            StreamWriter writer = new StreamWriter(Filename);
            using (writer)
            {
                writer.WriteLine(header);

                if (ReserveTransactions.Count > 0)
                {
                    foreach (string line in ReserveTransactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}
