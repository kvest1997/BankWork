using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using HM11._6.ViewModel.MainWindowPage;
using HM11._6.Views.AccountClients.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HM11._6.ViewModel.AccountsBank
{
    public class TransferAccountsBankViewModel : ViewModelBase
    {
        public Action UpdateAll;
        public ObservableCollection<AccountsInfo> AllCurrentAccountInfos { get; private set; }
        public ObservableCollection<ClientInfo> AllClientInfos { get; private set; }
        private readonly ClientInfo _currentClient;
        private readonly ClientsViewModel clientVM;
        private ITransferBalanceAccount<Account> TransferBalance { get; set; }


        public TransferAccountsBankViewModel()
        { }

        public TransferAccountsBankViewModel(ClientsViewModel clientsViewModel, ClientInfo clientInfo)
        {
            clientVM = clientsViewModel;
            _currentClient = clientInfo;

            AllClientInfos = new ObservableCollection<ClientInfo>();
            AllCurrentAccountInfos = new ObservableCollection<AccountsInfo>();            

            GetAllClient();
            GetAllAccount();

            UpdateAll += UpdateAlls;

            TransferBalance = new TransferBalanceAccount(clientVM.MainViewModel.Bank);

            TransferFromTo = new RelayCommand(OnTransferFromToExecuted,
                CanTransferFromToExecute);
            TransferAccountClientToClient = new RelayCommand(OnTransferAccountClientToClientExecuted,
                CanTransferBalanceExecute);
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void UpdateAlls()
        {
            AllCurrentAccountInfos.Clear();
            AllClientInfos.Clear();

            GetAllClient();
            GetAllAccount();
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        private void GetAllClient()
        {
            foreach (var c in clientVM.MainViewModel.Bank.GetClientInfos())
            {
                if (c.Id != _currentClient.Id)
                {
                    AllClientInfos.Add(c);
                }
            }
        }
        /// <summary>
        /// Получение нужных счетов
        /// </summary>
        private void GetAllAccount()
        {
            foreach (var account in clientVM.MainViewModel.Bank.GetAccountsInfos())
            {
                if (account.Client.Id == _currentClient.Id)
                {
                    AllCurrentAccountInfos.Add(account);
                }
            }
        }

        /// <summary>
        /// Реализация перевода между счетами
        /// </summary>
        #region TransferAccountBankFromTo
        private AccountsInfo _selectedAccountFrom;
        public AccountsInfo SelectedAccountFrom
        {
            get => _selectedAccountFrom;
            set => Set(ref _selectedAccountFrom, value);
        }

        private AccountsInfo _selectedAccountTo;
        public AccountsInfo SelectedAccountTo
        {
            get => _selectedAccountTo;
            set => Set(ref _selectedAccountTo, value);
        }

        private string _balanceFromTo;
        public string BalanceFromTo
        {
            get => _balanceFromTo;
            set => Set(ref _balanceFromTo, value);
        }


        public ICommand TransferFromTo { get; }
        private void OnTransferFromToExecuted(object p)
        {
            if (_selectedAccountFrom == null || 
                _selectedAccountTo == null || 
                String.IsNullOrEmpty(_balanceFromTo))
            {
                MessageBox.Show("Не выбраны счета");
                return;
            }

            if (_selectedAccountFrom.Equals(_selectedAccountTo) ||
                _selectedAccountTo.Equals(_selectedAccountFrom))
            {
                MessageBox.Show("Счета одинаковые");
                return;
            }

            int balanceFrom = Convert.ToInt32(SelectedAccountFrom.BalanceAccount);
            int balanceTo = Convert.ToInt32(SelectedAccountTo.BalanceAccount);
            int balanceFromTo = Convert.ToInt32(_balanceFromTo);

            if (balanceFromTo > balanceFrom)
            {
                MessageBox.Show($"Недостаточно средств, на балансе {balanceFrom}");
                return;
            }

            balanceFrom -= balanceFromTo;
            balanceTo += balanceFromTo;


            SelectedAccountFrom.BalanceAccount = $"{balanceFrom}";
            SelectedAccountTo.BalanceAccount = $"{balanceTo}";
            

            clientVM.MainViewModel.Bank.UpdateAccountBank(SelectedAccountFrom);
            clientVM.MainViewModel.Bank.UpdateAccountBank(SelectedAccountTo);

        }
        private bool CanTransferFromToExecute(object p) => true;
        #endregion


        /// <summary>
        /// Реализация перевода между пользователями
        /// </summary>
        #region TransferAccountBankClientToClient

        private AccountsInfo _selectAccountToClient;
        public AccountsInfo SelectAccountToClient
        {
            get => _selectAccountToClient;
            set => Set(ref _selectAccountToClient, value);
        }
        private int balanceTransfer;
        public int BalanceTransfer
        {
            get => balanceTransfer;
            set => Set(ref balanceTransfer, value);
        }
        private ClientInfo _selectedClient;
        public ClientInfo SelectedClient
        {
            get => _selectedClient;
            set => Set(ref _selectedClient, value);
        }

        public ICommand TransferAccountClientToClient { get; }
        private void OnTransferAccountClientToClientExecuted(object p)
        {
            TransferBalance.TransferBalance(SelectAccountToClient, SelectedClient, BalanceTransfer);
        }
        private bool CanTransferBalanceExecute(object p) => true;

        #endregion
    }
}
