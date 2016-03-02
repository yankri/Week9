using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
{
    class CheckingAccount : Accounts
    {
        decimal checkingBalance = 450;
        string checkingAcctNum = Clients.AccountNum.ToString() + "-00";
        List<string> checkingTransactions = new List<string>();
        string checkingFilename = "CheckingAccountSummary.txt";

        public decimal CheckingBalance { get; set; }
        public string CheckingAcctNum { get; set; }
        public List<string> CheckingTransactions { get; set; }
        public string CheckingFilename { get; set; }

        public CheckingAccount (Clients client)
        {
            CheckingBalance = checkingBalance;
            CheckingAcctNum = checkingAcctNum;
            this.client = client;
            CheckingTransactions = checkingTransactions;
            CheckingFilename = checkingFilename;
        }

        public void CADeposit(List<string> transactionhistory) //this method completes the deposit transaction, saving the information to a list. 
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
            sb.Append(total);
            sb.AppendLine();

            return sb.ToString();
        }


    }
}
