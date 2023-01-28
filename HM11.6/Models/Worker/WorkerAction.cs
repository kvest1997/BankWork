using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HM11._6.Models.Worker
{
    public class WorkerAction
    {
        public event Action<object, HistoryArgs> Post;
        public WorkerBase Worker { get; set; }

        public WorkerAction(WorkerBase worker)
        {
            this.Worker = worker;
        }

        public void PublicHistory(string typeAction, ClientInfo currentClient)
        {
            var args = new HistoryArgs()
            {
                Time = DateTime.Now.ToShortDateString(),
                TypeAction = typeAction,
                Client = currentClient.FIO,
                WorkerAction = Worker.ToString()
            };

            Post?.Invoke(this, args);

            Console.WriteLine($"В классе {this.GetType().Name}");
        }
    }
}
