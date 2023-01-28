using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models
{
    public class AppSetting
    {
        private string _clientRepositoryFile;
        private string _accountRepositoryFile;
        private string _historyRepositoryFile;
        public AppSetting()
        {
            Debug.WriteLine($"{this.GetType().Name} конструктор по умолчанию");

            _clientRepositoryFile = string.Empty;
            _accountRepositoryFile = string.Empty;
            _historyRepositoryFile = string.Empty;
        }

        /// <summary>
        /// Создание файла для настроек
        /// </summary>
        public string ClientRepositoryFile
        {
            get
            {
                if (string.IsNullOrEmpty(_clientRepositoryFile))
                    _clientRepositoryFile = @"clientsRep.json";
                return _clientRepositoryFile;
            }
            set => _clientRepositoryFile = value;
        }

        public string AccountRepositoryFile
        {
            get
            {
                if (string.IsNullOrEmpty(_accountRepositoryFile))
                    _accountRepositoryFile = @"accountRep.json";
                return _accountRepositoryFile;
            }

            set => _accountRepositoryFile = value;
        }

        public string HistoryRepositoryFile
        {
            get 
            {
                if (string.IsNullOrEmpty(_historyRepositoryFile))
                {
                    _historyRepositoryFile = @"historyRep.json";
                }
                return _historyRepositoryFile;
            }
            set => _historyRepositoryFile = value;

        }
    }
}
