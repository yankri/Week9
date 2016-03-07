using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDayTake2
{
    interface IBankAccounts
    {
        void Deposit();

        string DepositLineMaker(decimal amount, decimal totalToPrint);

        void Withdraw();

        string WithdrawLineMaker(decimal amount, decimal totalToPrint);

        void FileWriter(string filename);

        string FileHeader();
    }
}
