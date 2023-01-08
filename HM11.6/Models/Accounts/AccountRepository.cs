using HM11._6.Models.Clients;
using HM11._6.Models.PersonalData;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Accounts
{
    public class AccountRepository : IFileRepository<Account>
    {
        private static int Id;
        static AccountRepository()
        {
            Id = 0;
        }

        private static int NextId() => ++Id;


        private List<Account> _accounts;

        public List<Account> Accounts => _accounts;

        public int Count => Accounts.Count();

        private readonly string _path;

        public AccountRepository(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            _path = path;

            if (File.Exists(_path))
            {
                Load();
                return;
            }

            File.Create(_path);
            NoClientsForLoad();
        }

        /// <summary>
        /// Получение перечесление счетов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAllItemsRepository() => Accounts;


        /// <summary>
        /// Добавление счета в репозиторий
        /// </summary>
        /// <param name="client"></param>
        public void AddFileRepository(Account item)
        {
            if (item is null)
            {
                return;
            }
            item.Id = NextId();
            _accounts.Add(item);
            Save();
        }

        /// <summary>
        /// Редактирование счета в репозитории
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void EditFileRepository(Account item)
        {
            if (!_accounts.Any(c => c.Id == item.Id))
            {
                throw new ArgumentOutOfRangeException(nameof(item), "Такого клиента нет в списке");
            }

            _accounts[_accounts.IndexOf(_accounts.First(c => c.Id == item.Id))] = item;
            Save();
        }

        /// <summary>
        /// Удаление счета из репозитория
        /// </summary>
        /// <param name="idClient"></param>
        public void DeleteFileRepository(int itemId)
        {
            if (_accounts.Any(c => c.Id == itemId))
            {
                _accounts.Remove(_accounts.FirstOrDefault(c => c.Id == itemId));
            }
            else
            {
                Debug.WriteLine("Данного клиента нет!");
            }

            Save();
        }

        /// <summary>
        /// Полная отчистка всего репозитория
        /// </summary>
        public void ClearRepository()
        {
            if (Accounts is null)
            {
                return;
            }
            Accounts.Clear();
        }

        /// <summary>
        /// Сохранение Репозитория в файле
        /// </summary>
        private void Save()
        {
            string json = JsonConvert.SerializeObject(_accounts);
            File.WriteAllText(_path, json);
        }

        /// <summary>
        /// Загрузка из файла в репозиторий
        /// </summary>
        private void Load()
        {
            string data = File.ReadAllText(_path);

            if (string.IsNullOrEmpty(data))
            {
                NoClientsForLoad();
                return;
            }
            _accounts = JsonConvert.DeserializeObject<List<Account>>(data);

            if (_accounts is null)
            {
                NoClientsForLoad();
                return;
            }

            Id = Count > 0 ? _accounts.Max(c => c.Id) : 0;
        }

        /// <summary>
        /// Создание репозитория если при загрузки данных нет
        /// </summary>
        private void NoClientsForLoad()
        {
            _accounts = new List<Account>();
            Id = 0;
        }

        public IEnumerator<Account> GetEnumerator()
        {
            for (int i = 0; i < Accounts.Count(); i++)
            {
                yield return Accounts[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Поиск по Id счета
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Account GetItemById(int itemId)
        {
            if (_accounts.Any(a => a.Id == itemId))
            {
                return _accounts.FirstOrDefault(a => a.Id == itemId);
            }
            return null;
        }
    }
}
