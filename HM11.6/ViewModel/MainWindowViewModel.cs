using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.AppSettings;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.Models.Worker;
using HM11._6.ViewModel.Base;
using HM11._6.Views;
using HM11._6.Views.MainWindow.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using AppSettings = HM11._6.Models.AppSetting;

namespace HM11._6.ViewModel.MainWindowPage
{
    /// <summary>
    /// Создание экземпляров для главного окна
    /// </summary>
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IAppSetting _appSettingsRepository;

        public WorkerBase Worker { get; private set; }

        public AppSettings AppSettings { get; private set; }

        public Bank Bank { get; private set; }

        public MainWindowViewModel()
        {
            Debug.WriteLine($"Вызов конструктора по умолчанию {this.GetType().Name}");
        }

        public MainWindowViewModel(WorkerBase worker)
        {
            _appSettingsRepository = new AppSettingRepository();
            AppSettings = _appSettingsRepository.Load();

            Bank = new Bank("Bank HW11.6", new ClientFileRepository(AppSettings.ClientRepositoryFile),new AccountRepository(AppSettings.AccountRepositoryFile), new HistoryRepository(AppSettings.HistoryRepositoryFile), worker);
            _title = $"{Bank.Name}. Программа консультант";
            Worker = worker;
      
            _clients = new ClientsPage();
            _appSettings = new AppSettingPage();
            _clients.DataContext = new ClientsViewModel(this);
            _appSettings.DataContext = new AppSettingsViewModel(this);

            FrameOpacity = 1.0;
            CurrentPage = new EmptyPage();

            LogOutCommand = new RelayCommand(OnLogOutCommandExecuted,
                CanLogOutCommandExecuted);

            SetClientsView = new RelayCommand(OnSetClientsViewExecuted,
                CanSetClientsViewExecute);

            SetAppSettingsView = new RelayCommand(OnSetAppSettingsViewExecuted,
                CanSetAppSettingsViewExecute);
        }

        private readonly Page _clients;
        private readonly Page _appSettings;

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set 
            { 
                Set(ref _currentPage, value);
            }
        }

        private double _frameOpacity;
        public double FrameOpacity
        {
            get => _frameOpacity;
            set => Set(ref _frameOpacity, value);
        }

        public ICommand SetAppSettingsView { get; }
        private void OnSetAppSettingsViewExecuted(object p)
        {
            CurrentPage = _appSettings;
        }
        private bool CanSetAppSettingsViewExecute(object p) => true;

        public ICommand LogOutCommand { get; }
        private void OnLogOutCommandExecuted(object p) => LogOut(p);
        private bool CanLogOutCommandExecuted(object p) => true;

        public void LogOut(object p)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            if (p is Window window)
                window.Close();


        }

        public ICommand SetClientsView { get; }
        private void OnSetClientsViewExecuted(object p)
        {
            CurrentPage = _clients;
            if (_clients.DataContext is ClientsViewModel clientsViewModel)
            {
                clientsViewModel.UpdateClientsList.Invoke();
            }
        }

        private bool CanSetClientsViewExecute(object p) => true;

        private string _title;

        public string Title
        { 
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
