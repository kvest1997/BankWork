using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.PersonalData;
using HM11._6.Models.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models
{
    /// <summary>
    /// Модель банка
    /// </summary>
    public class Bank
    {
        public string Name { get; private set; }

        public IFileRepository<Client> ClientRepository { get; set; }
        public IFileRepository<Account> AccountsRepository { get; set; }
        public IFileRepository<HistoryArgs> HistoryRepository { get; set; }

        private readonly WorkerBase _worker;

        public Bank(string name, IFileRepository<Client> clientsRepository, IFileRepository<Account> accountsRepository, IFileRepository<HistoryArgs> historyRepository, WorkerBase worker)
        {
            Name = name;
            AccountsRepository = accountsRepository;
            ClientRepository = clientsRepository;
            HistoryRepository = historyRepository;
            _worker = worker;
        }

        public IEnumerable<HistoryArgs> GetHistory()
        {
            var history = new List<HistoryArgs>();

            foreach (var h in HistoryRepository)
            {
                history.Add(h);
            }

            return history;
        }

        /// <summary>
        /// Получение информации о клиентах в список
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ClientInfo> GetClientInfos()
        {
            var clientsInfo = new List<ClientInfo>();

            foreach (var client in ClientRepository)
            {
                clientsInfo.Add(_worker.GetClientInfo(client));
            }
            return clientsInfo;
        }

        /// <summary>
        /// Получение информации о счетах в списке
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountsInfo> GetAccountsInfos()
        {
            var accountInfo = new List<AccountsInfo>();

            foreach (var account in AccountsRepository)
            {
                accountInfo.Add(_worker.GetAccountInfo(account));
            }

            return accountInfo;
        }

        /// <summary>
        /// Добавление клиента в список
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            ClientRepository.AddFileRepository(client);
        }

        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="client"></param>
        public void EditClient(Client client)
        {
            ClientRepository.EditFileRepository(client);
        }

        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="client"></param>
        public void DeleteClient(Client client)
        {
            ClientRepository.DeleteFileRepository(client.Id);
        }

        /// <summary>
        /// Закрытие счета
        /// </summary>
        public void CloseAccountBank(Account account)
        {
            AccountsRepository.DeleteFileRepository(account.Id);
        }

        /// <summary>
        /// Открытие счета
        /// </summary>
        public void OpenAccountBank(Account account)
        {
            AccountsRepository.AddFileRepository(account);
        }

        /// <summary>
        /// Изменения при переводе
        /// </summary>
        /// <param name="account"></param>
        public void UpdateAccountBank(Account account)
        {
            AccountsRepository.EditFileRepository(account);
        }

        public void AddHistoryAction(HistoryArgs history)
        {
            HistoryRepository.AddFileRepository(history);
        }

        public void RemoveHistoryAction(HistoryArgs history)
        {
            HistoryRepository.DeleteFileRepository(history.Id);
        }
    }
}
