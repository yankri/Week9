using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9ProjectDay
{
    class Accounts
    {
        List<string> allAccountsTransactions = new List<string>();
        string checkingFile = "Checking Account Summary";
        string savingsFile = "Savings Account Summary";
        string reserveFile = "Reserve Account Summary";

        public string CheckingFile { get; set; }
        public string SavingsFile { get; set; }
        public string ReserveFile { get; set; }
        public static List<string> AllAccountsTransactions { get; set; }

        public Accounts ()
        {
            AllAccountsTransactions = allAccountsTransactions;
            CheckingFile = checkingFile;
            SavingsFile = savingsFile;
            ReserveFile = reserveFile;
        }

        public string AcctSummaryFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("All Accounts Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + Clients.AcctNum);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void AllAccountsFileWriter()  //writes the files at the end of the program
        {
            string header = AcctSummaryFileHeader();

            StreamWriter writer = new StreamWriter("AllAccountsSummary.txt");
            using (writer)
            {
                writer.WriteLine(header);

                if (AllAccountsTransactions.Count > 0)
                {
                    foreach (string line in AllAccountsTransactions)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }

    }
}
