using HM11._6.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Infastructure
{
    public interface ITransferBalanceAccount<in T>
    {
        void TransferBalance(T account, 
            ClientInfo selectedClient,
            int balanceTransfer);
    }
}
