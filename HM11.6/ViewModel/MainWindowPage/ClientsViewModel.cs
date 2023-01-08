using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.AccountsBank;
using HM11._6.ViewModel.Base;
using HM11._6.Views;
using HM11._6.Views.MainWindow;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HM11._6.ViewModel.MainWindowPage
{
    /// <summary>
    /// Прослойка для вывода данных на страницу 
    /// </summary>
    public class ClientsViewModel : ViewModelBase
    {
        public Action UpdateClientsList;
        public ObservableCollection<ClientInfo> Clients { get; }

        public MainWindowViewModel MainViewModel;

        public ClientsViewModel()
        {

        }

        public ClientsViewModel(MainWindowViewModel mainVM)
        {
            this.MainViewModel = mainVM;
            
            //Комманда добавление нового клиента
            AddClientCommand = new RelayCommand(OnAddClientCommandExecuted,
                CanAddClientCommandExecute);
            //Комманда для удалаение клиента
            DelClientCommand = new RelayCommand(OnDelClientCommandExecuted,
                CanDelClientCommandExecute);
            //Команда Редактирование клиента
            EditClientCommand = new RelayCommand(OnEditClientCommandExecuted,
                CanEditClientCommandExecute);

            //Команда открытия окна счетов клиента
            AccountClientCommand = new RelayCommand(OnAccountClientCommand, 
                CanAccountClientCommandExecute);

            Clients = new ObservableCollection<ClientInfo>();

            _enableAddClient = mainVM.Worker.UserAccess.Commands.AddClient;
            _enableDelClient = mainVM.Worker.UserAccess.Commands.DelClient;
            _enableEditClient = mainVM.Worker.UserAccess.Commands.EditClient && Clients.Count > 0;
            _enableAccountClient = mainVM.Worker.UserAccess.Commands.AccountClient;

            _selectedIndex = 0;
            UpdateClientsList += UpdateClients;
        }

        /// <summary>
        /// Обновление клиентов
        /// </summary>
        private void UpdateClients()
        {
            var selectedIndex = _selectedIndex;
            Clients.Clear();
            foreach (var clientInfo in MainViewModel.Bank.GetClientInfos())
            {
                Clients.Add(clientInfo);
            }

            SelectedIndex = selectedIndex;

            EnableEditClient = MainViewModel.Worker.UserAccess.Commands.EditClient && Clients.Count > 0;
        }


        public ICommand AddClientCommand { get; }
        private void OnAddClientCommandExecuted(object p)
        {
            ClientCardWindow clientCard = new ClientCardWindow();
            ClientCardViewModel clientCardViewModel = new ClientCardViewModel(new ClientInfo(), MainViewModel.Bank, this, MainViewModel.Worker.UserAccess);
            clientCard.DataContext = clientCardViewModel;
            clientCard.ShowDialog();
        }

        private bool CanAddClientCommandExecute(object p) => true;

        public ICommand DelClientCommand { get; }
        private void OnDelClientCommandExecuted(object p)
        {
            if (SelectedClient is null) return;

            MainViewModel.Bank.DeleteClient(SelectedClient);
            UpdateClients();
        }

        private bool CanDelClientCommandExecute(object p) => true;

        public ICommand EditClientCommand { get; }
        private void OnEditClientCommandExecuted(object p)
        {
            if (SelectedClient is null) return;

            ClientCardWindow clientCard = new ClientCardWindow();
            ClientCardViewModel clientCardViewModel = new ClientCardViewModel(SelectedClient, MainViewModel.Bank, this, MainViewModel.Worker.UserAccess);
            clientCard.DataContext = clientCardViewModel;
            clientCard.ShowDialog();
        }

        private bool CanEditClientCommandExecute(object p) => true;

        public ICommand AccountClientCommand { get; }
        private void OnAccountClientCommand(object p)
        {
            if (SelectedClient is null) return;

            AccountsClientWindow accountsClient = new AccountsClientWindow();
            AccountsBankViewModel accountsBankViewModel = new AccountsBankViewModel(this, SelectedClient);
            accountsClient.DataContext = accountsBankViewModel;
            accountsClient.ShowDialog();
        }
        private bool CanAccountClientCommandExecute(object p) => true;

        private bool _enableAddClient;
        public bool EnableAddClient
        {
            get => _enableAddClient;
            set => Set(ref _enableAddClient, value);
        }

        private bool _enableDelClient;
        public bool EnableDelClient
        {
            get => _enableDelClient;
            set => Set(ref _enableDelClient, value);
        }

        private bool _enableEditClient;
        public bool EnableEditClient
        { 
            get => _enableEditClient;
            set => Set(ref _enableEditClient, value);
        }

        private bool _enableAccountClient;
        public bool EnableAccountClient
        {
            get => _enableAccountClient;
            set => Set(ref _enableAccountClient, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        private ClientInfo _selectedClient;
        public ClientInfo SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }
    }
}
