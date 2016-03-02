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

        public string SavingsAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.SavingsFile);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = SavingsAcctFileHeader();
            List<string> transactions = this.SavingsTransactions;

            StreamWriter writer = new StreamWriter(Filename);
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
