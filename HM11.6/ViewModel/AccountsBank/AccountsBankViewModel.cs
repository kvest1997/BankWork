using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Infastructure.Commands;
using HM11._6.ViewModel.Base;
using HM11._6.ViewModel.MainWindowPage;
using HM11._6.Views.AccountClients.Pages;
using HM11._6.Views.MainWindow;
using HM11._6.Views.MainWindow.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace HM11._6.ViewModel.AccountsBank
{
    public class AccountsBankViewModel : ViewModelBase
    {
        public ClientsViewModel ClientsViewModel;

        public AccountsBankViewModel() { }

        public AccountsBankViewModel(ClientsViewModel clientsViewModel, ClientInfo clientInfo)
        {
            ClientsViewModel = clientsViewModel;


            _accountsPage = new AllAccountsBank
            {
                DataContext = new CurrentAccountBankViewModel(clientsViewModel, clientInfo, clientsViewModel.MainViewModel.Bank)
            };

            _transferPage = new TransferPage()
            {
                
                DataContext = new TransferAccountsBankViewModel(clientsViewModel, clientInfo)
            };


            FrameOpacity = 1.0;
            CurrentPage = new EmptyPage();


            OpenCurrentAccountBank = new RelayCommand(OnOpenCurrentAccountBankExecuted,
                CanOpenCurrentAccountBankExecuted);
            OpenTransferAccountBank = new RelayCommand(OnOpenTransferAccountBankExecuted, 
                CanOpenTranserAccountBankExecuted);
        }

        private readonly Page _accountsPage;
        private readonly Page _transferPage;

        private Page _currentPage;
        public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }

        private double _frameOpacity;
        public double FrameOpacity
        {
            get => _frameOpacity;
            set => Set(ref _frameOpacity, value);
        }

        /// <summary>
        /// Окно перевода средств
        /// </summary>
        public ICommand OpenTransferAccountBank { get; }
        private bool CanOpenTranserAccountBankExecuted(object p) => true;
        private void OnOpenTransferAccountBankExecuted(object p)
        {
            CurrentPage = _transferPage;
            if (_transferPage.DataContext is TransferAccountsBankViewModel trsfAccountsBankVM)
                trsfAccountsBankVM.UpdateAll.Invoke();
        }

        /// <summary>
        /// Окно открытия текущих счетов
        /// </summary>
        public ICommand OpenCurrentAccountBank { get;  }
        private bool CanOpenCurrentAccountBankExecuted(object p) => true;
        private void OnOpenCurrentAccountBankExecuted(object p)
        {
            CurrentPage = _accountsPage;
            if (_accountsPage.DataContext is CurrentAccountBankViewModel currentAccountBankViewModel)
            {
                currentAccountBankViewModel.UpdateAccountsList.Invoke();
            }
        }


    }
}
