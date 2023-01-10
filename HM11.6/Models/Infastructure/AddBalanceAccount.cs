using HM11._6.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Infastructure
{
    public class AddBalanceAccount : IAddBalanceAccount<Account>
    {
        private Account currentAccount;
        public AddBalanceAccount(Account account) 
        {
            currentAccount = account;
        }
        

        /// <summary>
        /// Добавление денежных средств на счет
        /// </summary>
        /// <param name="balance">Кол-во пополнений</param>
        /// <returns>Возвращается обновленный счет</returns>
        public Account AddBalance(int balance)
        {
            int currentBalance = Convert.ToInt32(currentAccount.BalanceAccount);

            currentAccount.BalanceAccount = Convert.ToString(balance+ currentBalance);

            return currentAccount;
        }
    }
}
