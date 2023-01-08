using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Accounts
{
    public class NoDepositAccount : Account
    {
        public NoDepositAccount(Account account) : base(account.Client,account.BankAccount, account.BalanceAccount)
        {
            Id = account.Id;
            TypeAccount = "Не депозитный";
        }

        public override string ToString()
        {
            return "Не депозитный";
        }
    }
}
