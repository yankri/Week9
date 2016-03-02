using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week8ProjectDay
{
    class SavingsAccount : Accounts
    {
        decimal savingsBalance = 500;
        string savingsAccountNum = Clients.AccountNum.ToString() + "-01";
        List<string> savingsTransactions = new List<string>();
        string savingsFilename = "SavingsAccountSummary.txt";

        public decimal SavingsBalance { get; set; }
        public string SavingsAcctNum { get; set; }
        public List<string> SavingsTransactions { get; set; }
        public string SavingsFilename { get; set; }

        public SavingsAccount (Clients client)
        {
            SavingsBalance = savingsBalance;
            SavingsAcctNum = savingsAccountNum;
            this.client = client;
            SavingsTransactions = savingsTransactions;
            SavingsFilename = savingsFilename;
        }

        public void SADeposit(List<string> transactionhistory) //this method completes the deposit transaction, saving the information to a list. 
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
            sb.Append(total);
            sb.AppendLine();

            return sb.ToString();
        }



    }
}
