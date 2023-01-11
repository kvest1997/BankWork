using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using System.Collections.Generic;
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

<<<<<<< HEAD
        /// <summary>
        /// Проверка на тип аккаунта
        /// </summary>
        /// <param name="typeAccount">Выбранный тип</param>
        /// <returns>Возвращает ложь или истина при проверке</returns>
=======
>>>>>>> 04b96711e96d7ba8356df3f6d30b72b15b5451cb
        private bool CheckTypeAccount(TypeAccount typeAccount)
        {
            bool flag = false;
            foreach (var item in _bank.GetAccountsInfos())
            {
                if (item.Client.Id == _currentClient.Id && item.TypeAccountBank == typeAccount)
                {
                    MessageBox.Show($"{typeAccount} счет уже есть");
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

<<<<<<< HEAD
        #region SaveNewAccountBank
=======
>>>>>>> 04b96711e96d7ba8356df3f6d30b72b15b5451cb
        public ICommand SaveNewAccountBank { get; }
        private bool CanSaveNewAccontBankExecute(object p) => true;
        private void OnSaveNewAccountBankExecuted(object p)
        {
            var accountTemp = new Account(_currentClient, _accountBank, _balance);
            Account account;

            if (CheckTypeAccount(_typeAccountBank))
            {
                return;
            }

            switch (_typeAccountBank)
            {
                case TypeAccount.DEPOSIT:
                    account = new DepositAccount(accountTemp);
                    break;
                case TypeAccount.NEDEPOSIT: 
                    account = new NoDepositAccount(accountTemp);
                    break;
                default: MessageBox.Show("Не выбран тип аккаунта"); account = null;
                    break;
            }

            if (account != null)
            {
                _bank.OpenAccountBank(account);
                _currentAccountViewModel.UpdateAccountsList.Invoke();

                if (p is Window win)
                    win.Close();
            }
        }
        #endregion

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
        private TypeAccount _typeAccountBank;
        public TypeAccount TypeAccountBank
        {
            get => _typeAccountBank;
            set => Set(ref _typeAccountBank, value);
        }
        #endregion
    }
}
