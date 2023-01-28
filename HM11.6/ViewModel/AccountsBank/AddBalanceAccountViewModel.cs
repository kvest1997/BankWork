using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Infastructure;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HM11._6.ViewModel.AccountsBank
{
    public class AddBalanceAccountViewModel : ViewModelBase
    {
        private IAddBalanceAccount<Account> addAccountBalance;
        private CurrentAccountBankViewModel currentAccountBankVM;
        public AccountsInfo currentAccount;
        private Bank _bank;
        public AddBalanceAccountViewModel() { }

        public AddBalanceAccountViewModel(AccountsInfo account, 
            Bank bank, CurrentAccountBankViewModel currentAccountBankVM)
        {
            currentAccount = account;
            _bank = bank;
            addAccountBalance = new AddBalanceAccount(account);
            this.currentAccountBankVM = currentAccountBankVM;

            AddBalance = new RelayCommand(OnAddBalanceExecuted,
                CanAddBalanceExecute);
        }

        /// <summary>
        /// Реализация добавления денежных средств на счет
        /// </summary>
        #region AddBalanceToAccount

        private void AddBalanceToAccount()
        {
            currentAccount = (AccountsInfo)addAccountBalance.AddBalance(_addBalanceCount);
            _bank.UpdateAccountBank(currentAccount);
            
        }

        public ICommand AddBalance { get; }
        private void OnAddBalanceExecuted(object p)
        {
            AddBalanceToAccount();
            currentAccountBankVM.UpdateAccountsList.Invoke();

            if (p is Window win)
            {
                win.Close();
            }
        }
        private bool CanAddBalanceExecute(object p) => true;

        private int _addBalanceCount;
        public int AddBalanceCount
        {
            get => _addBalanceCount;
            set => Set(ref _addBalanceCount, value);
        }

        public string AccountBankString
        {
            get
            {
                if (currentAccount is null)
                {
                    return "";
                }
                return currentAccount.BankAccount;
            }
        }
        #endregion
    }
}
