using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Accounts
{
    public class AccountsInfo : Account
    {
        public AccountsInfo(Account account):base(account.Client,account.BankAccount,account.BalanceAccount)
        {
            Id = account.Id;
            TypeAccountBank = account.TypeAccountBank;
        }

        public override string ToString()
        {
            string type;
            switch (TypeAccountBank)
            {
                case TypeAccount.DEPOSIT: type = "Депозитный";
                    break;
                case TypeAccount.NEDEPOSIT: type = "Не депозитный";
                    break;
                default: type = "Error Type";
                    break;
            }

            return type;
        }
    }
}
