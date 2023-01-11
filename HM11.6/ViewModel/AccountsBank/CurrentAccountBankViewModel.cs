using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using HM11._6.ViewModel.MainWindowPage;
using HM11._6.Views.AccountClients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace HM11._6.ViewModel.AccountsBank
{
    public class CurrentAccountBankViewModel : ViewModelBase
    {
        public Action UpdateAccountsList;

        public ClientsViewModel ClientsViewModel;
        public ClientInfo ClientInfo;

        private Bank _bank { get; set; }

        public ObservableCollection<AccountsInfo> Accounts { get; }


        public CurrentAccountBankViewModel()
        { }

        public CurrentAccountBankViewModel(ClientsViewModel clientsView, ClientInfo clientInfo, Bank bank)
        {
            ClientsViewModel = clientsView;
            ClientInfo = clientInfo;

            _bank = bank;

            Accounts = new ObservableCollection<AccountsInfo>();

            UpdateAccountsList += UpdateAccounts;
            OpenNewAccountBank = new RelayCommand(OnOpenNewAccountBankExecuted, CanOpenNewAccountBankExecute);
            CloseAccountBank = new RelayCommand(OnCloseAccountBankExecuted, CanCloseAccountBankExecute);
            AddBalanceAccount = new RelayCommand(OnAddBalanceAccountExecuted,
                CanAddBalanceAccountExecute);
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void UpdateAccounts()
        {
            var selectedIndex = _selectedIndex;
            Accounts.Clear();
            foreach (var accountInfo in ClientsViewModel.MainViewModel.Bank.GetAccountsInfos())
            {
                if (ClientInfo.Id == accountInfo.Client.Id)
                {
                    Accounts.Add(accountInfo);
                }
            }
            SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Команда на добавление денежных средств
        /// </summary>
        #region AddBalanceAccount
        public ICommand AddBalanceAccount { get; }
        private void OnAddBalanceAccountExecuted(object p)
        {
            AddBalanceWindow addBalanceWindow = new AddBalanceWindow();
            AddBalanceAccountViewModel addBalanceAccountVM = new AddBalanceAccountViewModel(SelectedAccount, _bank, this);
            addBalanceWindow.DataContext = addBalanceAccountVM;
            addBalanceWindow.ShowDialog();

            if (p is Window win)
                win.Close();
        }
        private bool CanAddBalanceAccountExecute(object p) => true;
        #endregion

        /// <summary>
        /// Проверка на кол-во аккаунтов
        /// </summary>
        /// <returns></returns>
        private bool CheckAccountBank()
        {
            bool flag = false;

            if (Accounts.Count == 2)
                flag = true;

            return flag;
        }

        /// <summary>
        /// Открытие нового счета
        /// </summary>
        #region OpenNewAccountBank


        private bool CheckAccountBank()
        {
            bool flag = false;

            if (Accounts.Count == 2)
                flag = true;

            return flag;
        }

        public ICommand OpenNewAccountBank { get; }
        private void OnOpenNewAccountBankExecuted(object p)
        {
            if (CheckAccountBank())
            {
                MessageBox.Show("Клиент может иметь только 2 счета");
                return;
            }

            AccountBankOpenWindow accountBankOpenWindow = new AccountBankOpenWindow();
            AccountBankOpenViewModel accountBankOpenViewModel = new AccountBankOpenViewModel(_bank, this, ClientInfo);
            accountBankOpenWindow.DataContext = accountBankOpenViewModel;
            accountBankOpenWindow.ShowDialog();

        }
        private bool CanOpenNewAccountBankExecute(object p) => true;
        #endregion


        /// <summary>
        /// Закрытие счета
        /// </summary>
        #region CloseAccountBank
        public ICommand CloseAccountBank { get; }
        private void OnCloseAccountBankExecuted(object p)
        {
            if (SelectedAccount is null) return;

            _bank.CloseAccountBank(SelectedAccount);
            UpdateAccountsList.Invoke();
        }
        private bool CanCloseAccountBankExecute(object p) => true;
        #endregion
        private AccountsInfo _selectedAccount;
        public AccountsInfo SelectedAccount
        {
            get => _selectedAccount;
            set => Set(ref _selectedAccount, value);
        }

        private int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

    }
}
