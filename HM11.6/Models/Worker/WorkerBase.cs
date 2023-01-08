using HM11._6.Models.Accounts;
using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Worker
{
    /// <summary>
    /// Абстрактный класс, является базовым для любого сотрудника
    /// </summary>
    public abstract class WorkerBase
    {
        public UserAccess UserAccess { get; protected set; }

        public abstract ClientInfo GetClientInfo(Client client);
        public abstract AccountsInfo GetAccountInfo(Account account);
    }
}
