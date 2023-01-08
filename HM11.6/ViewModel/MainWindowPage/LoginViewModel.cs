using HM11._6.Models.Infastructure.Commands;
using HM11._6.Models.Worker;
using HM11._6.ViewModel.Base;
using HM11._6.ViewModel.MainWindowPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HM11._6.ViewModel
{
    /// <summary>
    /// Прослойка для открытие приложения с нужными правами
    /// </summary>
    internal class LoginViewModel : ViewModelBase
    {
        public ICommand SetConsultantMode { get; }
        private void OnSetConsultantModeExecuted(object p)
        {
            OpenMainWindow(new Consultant(), p);
        }
        public ICommand SetManagerMode { get; }
        private void OnSetManagerModeExecuted(object p)
        {
            OpenMainWindow(new Manager(), p);
        }

        private bool CanSetMagaerModeExecute(object p) => true;


        private void OpenMainWindow(WorkerBase worker, object p)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.DataContext = new MainWindowViewModel(worker);
            mainWindow.Show();

            if (p is Window window)
            {
                window.Close();
            }
        }

        public LoginViewModel()
        {
            SetConsultantMode = new RelayCommand(OnSetConsultantModeExecuted, CanSetMagaerModeExecute);
            SetManagerMode = new RelayCommand(OnSetManagerModeExecuted, CanSetMagaerModeExecute);
        }


    }
}
