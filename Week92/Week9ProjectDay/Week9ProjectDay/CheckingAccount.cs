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

        public string CheckingAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.CheckingFile);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = CheckingAcctFileHeader();
            List<string> transactions = this.CheckingTransactions;

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
