using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Worker
{
    /// <summary>
    /// Модель менеджера с правами доступа
    /// </summary>
    public class Manager : WorkerBase
    {
        public Manager()
        {
            UserAccess = new UserAccess(
                new CommnadsAccess
                {
                    AddClient = true,
                    EditClient = true,
                    DelClient = true,
                    AccountClient = true
                },
                new EditFieldAccess()
                {
                    FirstName = true,
                    Surname = true,
                    LastName = true,
                    PassportData = true,
                    PhoneNumber = true,
                    Account = true

                });
        }

        /// <summary>
        /// Переопределение метода для вывода серии паспорта и номера
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public override ClientInfo GetClientInfo(Client client)
        {
            var clientInfo = new ClientInfo(client)
            {
                PassportSerie = client.PassportData.SerialPassport.ToString(),
                PassportNumber = client.PassportData.NumberPassport.ToString(),
            };

            return clientInfo;
        }

        public override AccountsInfo GetAccountInfo(Account account)
        {
            var accountInfo = new AccountsInfo(account);

            return accountInfo;
        }

        public override string ToString()
        {
            return "Менеджер";
        }
    }
}
