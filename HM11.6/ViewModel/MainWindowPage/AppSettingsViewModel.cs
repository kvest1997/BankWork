using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.AppSettings;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.Models.PersonalData;
using HM11._6.ViewModel.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HM11._6.ViewModel.MainWindowPage
{
    /// <summary>
    /// Привязка комманд к модели через интерфейс
    /// </summary>
    public class AppSettingsViewModel : ViewModelBase
    {
        private IAppSetting _appSettingRepository;
        private readonly AppSetting _appSetting;

        private readonly MainWindowViewModel _mainViewModel;

        public AppSettingsViewModel()
        {

        }

        public AppSettingsViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainViewModel = mainWindowViewModel; 
            _appSetting = mainWindowViewModel.AppSettings;

            SaveAppSettingsCommand = new RelayCommand(OnSaveAppSettingsCommandExecuted,
                CanSaveAppSettingsCommandExecute);

            GetTestClientsCommand = new RelayCommand(OnGetTestClientsCommandExecuted,
                CanGetTestClientsCommandExecute);
        }

        public ICommand SaveAppSettingsCommand { get; }

        /// <summary>
        /// Создание экземпляра настроек
        /// </summary>
        /// <param name="p"></param>
        private void OnSaveAppSettingsCommandExecuted(object p)
        {
            _appSettingRepository = new AppSettingRepository();
            _appSettingRepository.Save(_appSetting);
        }

        private bool CanSaveAppSettingsCommandExecute(object p) => true;
        
        public ICommand GetTestClientsCommand { get; }

        /// <summary>
        /// Генерация случайных данных
        /// </summary>
        /// <param name="p"></param>
        private void OnGetTestClientsCommandExecuted(object p)
        {
            IEnumerable<Client> clients = Enumerable.Range(1, 20).Select(i => new Client
            (
                new Models.PersonalData.NumberPhone($"7900800{i++}{++i}"),
                new Models.PersonalData.PassportData($"{1000 + i}", $"{50000 + i}"),
                $"Имя {i}",
                $"Фамилия {i}",
                $"Отчество {i}"
            ));

            ClientFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"clientsRep.json");
            _appSetting.ClientRepositoryFile = ClientFilePath;
            ClientFileRepository clientsRepository = new ClientFileRepository(ClientFilePath);

            List<Client> tempClient = new List<Client>();
            foreach (var c in clients)
            {
                clientsRepository.AddFileRepository(c);
                tempClient.Add(c);
            }

            _mainViewModel.Bank.ClientRepository = new ClientFileRepository(_appSetting.ClientRepositoryFile);


            IEnumerable<Account> accounts = Enumerable.Range(0, tempClient.Count()-1).Select(i => new DepositAccount( new Account
            (
                tempClient[i], 
                $"{Account.SetAccountBank()}",
                $"{i}"
            )));


            AccountFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"accountRep.json");
            _appSetting.AccountRepositoryFile = AccountFilePath;

            AccountRepository accountsRep = new AccountRepository(AccountFilePath);

            foreach (var a in accounts)
            {
                accountsRep.AddFileRepository(a);
            }
            _mainViewModel.Bank.AccountsRepository = new AccountRepository(_appSetting.AccountRepositoryFile);

        }

        private bool CanGetTestClientsCommandExecute(object p) => true;

        private string _clientFilePath;
        public string ClientFilePath
        {
            get => _appSetting?.ClientRepositoryFile ?? string.Empty;
            set
            {
                Set(ref _clientFilePath, value);
                _appSetting.ClientRepositoryFile = _clientFilePath;
            }
        }

        private string _accountFilePath;

        public string AccountFilePath
        {
            get => _appSetting?.AccountRepositoryFile ?? string.Empty;
            set
            {
                Set(ref _accountFilePath, value);
                _appSetting.AccountRepositoryFile = _accountFilePath;
            }
        }
    }
}
