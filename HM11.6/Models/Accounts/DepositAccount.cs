using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Accounts
{
    public class DepositAccount : Account
    {
        public DepositAccount(Account account) : 
            base(account.Client,account.BankAccount,account.BalanceAccount)
        {
            Id = account.Id;
            TypeAccountBank = TypeAccount.DEPOSIT;
        }

        public override string ToString()
        {
            return "Депозитный";
        }
    }
}
