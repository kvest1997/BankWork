using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HM11._6.ViewModel.AccountsBank
{
    public class AccountBankOpenViewModel : ViewModelBase
    {
        private Bank _bank { get; set; }
        private readonly CurrentAccountBankViewModel _currentAccountViewModel;
        private ClientInfo _currentClient { get; set; }
        
        public AccountBankOpenViewModel(Bank bank, 
            CurrentAccountBankViewModel currentAccountBank,
            ClientInfo currentClient)
        {
            _bank = bank;
            _currentAccountViewModel = currentAccountBank;
            _currentClient = currentClient;

            SaveNewAccountBank = new RelayCommand(OnSaveNewAccountBankExecuted,
                CanSaveNewAccontBankExecute);
        }

        public ICommand SaveNewAccountBank { get; }
        private bool CanSaveNewAccontBankExecute(object p) => true;
        private void OnSaveNewAccountBankExecuted(object p)
        {
            var account = new DepositAccount(new Account(_currentClient, _accountBank, _balance));

            _bank.OpenAccountBank(account);
            _currentAccountViewModel.UpdateAccountsList.Invoke();

            if (p is Window win)
                win.Close();
        }

        #region AccountBank
        private string _accountBank = Account.SetAccountBank();
        public string AccountBank
        {
            get => _accountBank;
            set => Set(ref _accountBank, value);
        }
        #endregion

        #region Balance
        private string _balance;
        public string Balance
        {
            get => _balance;
            set => Set(ref _balance, value);
        }
        #endregion

        #region TypeAccount

        #endregion
    }
}
