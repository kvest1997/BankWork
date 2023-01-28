using HM11._6.Models;
using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using HM11._6.Models.Worker;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.ViewModel
{
    public class HistoryListViewModel
    {
        public Action UpdateHistoryList;
        public ObservableCollection<HistoryArgs> HistoryArgs { get; set; }
        private Bank _bank;
        public HistoryListViewModel() { }
        public HistoryListViewModel(Bank bank)
        {
            HistoryArgs = new ObservableCollection<HistoryArgs>();
            _bank = bank;
            UpdateHistoryList += UpdateHistory;
            UpdateHistory();
        }

        private void UpdateHistory()
        {
            HistoryArgs.Clear();
            foreach (var history in _bank.GetHistory())
                HistoryArgs.Add(history);
        }

        public void WorkerActionSave(object arg1, HistoryArgs arg2)
        {
            HistoryArgs.Add(arg2);
            _bank.HistoryRepository.AddFileRepository(arg2);
        }
    }
}
