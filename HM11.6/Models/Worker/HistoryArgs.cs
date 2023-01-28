using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Worker
{
    public class HistoryArgs
    {
        /// <summary>
        /// Структура аргумента истории
        /// </summary>
        public int Id { get; set; }
        public string Time { get; set; }
        public string TypeAction { get; set; }
        public string Client { get; set; }
        public string WorkerAction { get; set; }
    }
}
