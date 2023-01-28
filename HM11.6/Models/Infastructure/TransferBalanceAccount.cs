using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HM11._6.Models.Infastructure
{
    public class TransferBalanceAccount : ITransferBalanceAccount<Account>
    {
        private readonly Bank Bank; //Для сохранения нового результата
        public TransferBalanceAccount(Bank bank)
        {
            Bank = bank;
        }

        /// <summary>
        /// Реализация интерфеса для перевода между пользователями
        /// </summary>
        /// <param name="account">Счет откуда переводим</param>
        /// <param name="selectedClient">Кому переводим</param>
        /// <param name="balanceTransfer">Сколько переводим</param>
        public void TransferBalance(Account account, ClientInfo selectedClient,
            int balanceTransfer)
        {
            AccountsInfo accountSelectedClient = null;
            int currentBalance = Convert.ToInt32(account.BalanceAccount);


            if (!(currentBalance >= balanceTransfer && currentBalance > 0))
            {
                MessageBox.Show($"Недостаточно средств {currentBalance}");
                return;
            }

            int balanceSelectedClient = 0;
            foreach (var a in Bank.GetAccountsInfos())
            {
                if (a.Client.Id == selectedClient.Id)
                {
                    accountSelectedClient = a;
                    balanceSelectedClient = Convert.ToInt32(accountSelectedClient.BalanceAccount);
                    break;
                }
            }

            if (accountSelectedClient != null)
            {
                accountSelectedClient.BalanceAccount = Convert.ToString(balanceSelectedClient + balanceTransfer);
                account.BalanceAccount = Convert.ToString(currentBalance - balanceTransfer);

                Bank.UpdateAccountBank(accountSelectedClient);
                Bank.UpdateAccountBank(account);
            }

        }
    }
}
