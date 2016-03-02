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

        public string ReserveAcctFileHeader() //creates the header for the account summary file
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Account Summary");
            sb.AppendLine();
            sb.AppendLine("Account Holder: " + Clients.AccountHolder);
            sb.AppendLine();
            sb.AppendLine("Account Number: " + this.ReserveFile);
            sb.AppendLine();
            sb.AppendLine("Date/Time\t\tType\tAmount\tCurrent Balance");

            return sb.ToString();
        }

        public void FileWriter()  //writes the files at the end of the program
        {
            string header = ReserveAcctFileHeader();
            List<string> transactions = this.ReserveTransactions;

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
