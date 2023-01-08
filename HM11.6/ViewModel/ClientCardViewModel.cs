using HM11._6.Models;
using HM11._6.Models.Clients;
using HM11._6.Models.Worker;
using HM11._6.ViewModel.Base;
using System;
using System.Windows.Input;
using HM11._6.Views;
using HM11._6.Models.PersonalData;
using System.Windows;
using HM11._6.Models.Infastructure.Commands;
using System.Diagnostics;
using HM11._6.ViewModel.MainWindowPage;

namespace HM11._6.ViewModel
{
    /// <summary>
    /// Прослойка для работы с карточкой клиента
    /// </summary>
    public class ClientCardViewModel : ViewModelBase
    {
        private ClientInfo _currentInfo { get; set; } // Текущая информация о клиенте
        private Bank _bank { get; set; }
        private readonly ClientsViewModel _clientsViewModel;


        public ClientCardViewModel(ClientInfo clientInfo, Bank bank, ClientsViewModel clientsViewModel, UserAccess userAccess)
        {
            Debug.WriteLine($"Вызов конструктора {this.GetType().Name} с параметрами: {nameof(clientInfo)} {nameof(bank)} {nameof(clientsViewModel)} {nameof(userAccess)}");

            _currentInfo = clientInfo;
            _bank = bank;
            _clientsViewModel = clientsViewModel;

            FillFields(clientInfo);
            EnableFields(userAccess);
            CheckSaveClient();

            SaveClientData = new RelayCommand(OnSaveClientDataExecuted, CanSaveClientDataExecute);
            
        }

        /// <summary>
        /// Включение\отключение на ввод определеных данных
        /// </summary>
        /// <param name="userAccess"></param>
        private void EnableFields(UserAccess userAccess)
        {
            _enableFirstName = userAccess.EditAccess.FirstName;
            _enableSurname = userAccess.EditAccess.Surname;
            _enableLastName = userAccess.EditAccess.LastName;
            _enablePassportData = userAccess.EditAccess.PassportData;
            _enablePhoneNumber = userAccess.EditAccess.PhoneNumber;

            _borderFirstName = InputHighlighting(_enableFirstName, _firstName.Length > 0);
            _borderSurname = InputHighlighting(_enableSurname, _surname.Length > 0);
            _borderLastName = InputHighlighting(_enableLastName, _lastName.Length > 0);

            _borderPassportSerie = InputHighlighting(_enablePassportData, PassportData.IsSerial(_passportSerie));
            _borderPassportNumber = InputHighlighting(_enablePassportData, PassportData.IsNumber(_passportNumber));

            _borderPhoneNumber = InputHighlighting(_enablePhoneNumber, Models.PersonalData.NumberPhone.IsPhoneNumber(_phoneNumber));
        }
        /// <summary>
        /// Заполнение данных выбранного клиента или нового
        /// </summary>
        /// <param name="clientInfo"></param>
        private void FillFields(ClientInfo clientInfo)
        {
            if (clientInfo is null)
            {
                return;
            }

            _firstName = clientInfo.FirstName ?? String.Empty;
            _surname = clientInfo.Surname ?? String.Empty;
            _lastName = clientInfo.LastName ?? String.Empty;
            _phoneNumber = clientInfo.NumberPhone?.ToString() ?? String.Empty;
            _passportNumber = clientInfo.PassportNumber ?? String.Empty;
            _passportSerie = clientInfo.PassportSerie ?? String.Empty;
        }
        
        /// <summary>
        /// Проверка на валидность данных при заполнении
        /// </summary>
        private void CheckSaveClient()
        {
            EnableSaveClient = _borderFirstName != InputValueHighlightingEnum.Error
                && _borderLastName != InputValueHighlightingEnum.Error
                && _borderSurname != InputValueHighlightingEnum.Error
                && _borderPassportSerie != InputValueHighlightingEnum.Error
                && _borderPassportNumber != InputValueHighlightingEnum.Error
                && _borderPhoneNumber != InputValueHighlightingEnum.Error;
        }

        /// <summary>
        /// Возращает состояние валидности
        /// </summary>
        /// <param name="isEnable"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        private InputValueHighlightingEnum InputHighlighting(bool isEnable, bool isValid)
        {
            if (!isEnable) 
            {
                return InputValueHighlightingEnum.Disable;
            }
            if (!isValid)
            {
                return InputValueHighlightingEnum.Error;
            }

            return InputValueHighlightingEnum.Default;
        }

        #region SaveClient
        public ICommand SaveClientData { get; }
        private void OnSaveClientDataExecuted(object p)
        {
            var client = new Client(
                 new NumberPhone(_phoneNumber),
                _enablePassportData ? new PassportData(_passportSerie, _passportNumber) :
                new PassportData(_currentInfo.PassportData.SerialPassport, 
                _currentInfo.PassportData.NumberPassport),
                _firstName, _surname, _lastName) ;

            if (_currentInfo.Id == 0)
            {
                _bank.AddClient(client);
            }
            else
            {
                client.Id = _currentInfo.Id;
                _bank.EditClient(client);
            }

            _clientsViewModel.UpdateClientsList.Invoke();

            if (p is Window window)
            {
                window.Close();
            }
        }
        private bool CanSaveClientDataExecute(object p) => true;
        #endregion

        #region EnableSaveClient
        private bool _enableSaveClient;
        public bool EnableSaveClient
        {
            get => _enableSaveClient;
            set => Set(ref _enableSaveClient, value);
        }
        #endregion

        #region FirstName
        private bool _enableFirstName;
        public bool EnableFirstName
        {
            get => _enableFirstName;
            set => Set(ref _enableFirstName, value);
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                Set(ref _firstName, value);
                BorderFirstName = InputHighlighting(_enableFirstName, _firstName.Length > 2);
            }
        }

        private InputValueHighlightingEnum _borderFirstName;
        public InputValueHighlightingEnum BorderFirstName
        {
            get => _borderFirstName;
            set
            {
                Set(ref _borderFirstName, value);
                CheckSaveClient();
            }
        }
        #endregion

        #region Surname
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                Set(ref _surname, value);
                BorderSurname = InputHighlighting(_enableSurname, _surname.Length > 2);
            }
        }
        private bool _enableSurname;
        public bool EnableSurname
        {
            get => _enableSurname;
            set => Set(ref _enableSurname, value);
        }

        private InputValueHighlightingEnum _borderSurname;
        public InputValueHighlightingEnum BorderSurname
        {
            get => _borderSurname;
            set
            {
                Set(ref _borderSurname, value);
                CheckSaveClient();
            }
        }
        #endregion

        #region LastName

        private string _lastName;
        public string LastName
        { 
            get => _lastName;
            set
            {
                Set(ref _lastName, value);
                BorderLastName = InputHighlighting(_enableLastName, _lastName.Length > 2);
            }
        }

        private bool _enableLastName;
        public bool EnableLastName
        {
            get => _enableLastName;
            set => Set(ref _enableLastName, value);
        }

        private InputValueHighlightingEnum _borderLastName;
        public InputValueHighlightingEnum BorderLastName
        {
            get => _borderLastName;
            set
            {
                Set(ref _borderLastName, value);
                CheckSaveClient();
            }
        }
        #endregion

        #region NumberPhone
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                Set(ref _phoneNumber, value);
                BorderPhoneNumber = InputHighlighting(_enablePhoneNumber, Models.PersonalData.NumberPhone.IsPhoneNumber(_phoneNumber));
            }
        }

        private bool _enablePhoneNumber;
        public bool EnablePhoneNumber
        {
            get => _enablePhoneNumber;
            set => Set(ref _enablePhoneNumber, value);
        }

        private InputValueHighlightingEnum _borderPhoneNumber;
        public InputValueHighlightingEnum BorderPhoneNumber
        {
            get => _borderPhoneNumber;
            set
            {
                Set(ref _borderPhoneNumber, value);
                CheckSaveClient();
            }
        }

        #endregion

        #region PasspordData

        private string _passportSerie;
        public string PassportSerie
        {
            get => _passportSerie;
            set
            {
                Set(ref _passportSerie, value);
                BorderPassportSerie = InputHighlighting(_enablePassportData, PassportData.IsSerial(_passportSerie));
            }
        }

        private InputValueHighlightingEnum _borderPassportSerie;
        public InputValueHighlightingEnum BorderPassportSerie
        {
            get => _borderPassportSerie;
            set
            {
                Set(ref _borderPassportSerie, value);
                CheckSaveClient();
            }
        }

        private string _passportNumber;
        public string PasportNumber
        {
            get => _passportNumber;
            set
            {
                Set(ref _passportNumber, value);
                BorderPassportNumber = InputHighlighting(_enablePassportData, PassportData.IsNumber(_passportNumber));
            }
        }

        private InputValueHighlightingEnum _borderPassportNumber;
        public InputValueHighlightingEnum BorderPassportNumber
        {
            get => _borderPassportNumber;
            set
            {
                Set(ref _borderPassportNumber, value);
                CheckSaveClient();
            }
        }

        private bool _enablePassportData;
        public bool EnablePassportData
        {
            get => _enablePassportData;
            set => Set(ref _enablePassportData, value);
        }

        #endregion
    }
}
