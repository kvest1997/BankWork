using HM11._6.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Infastructure
{
    public interface IAddBalanceAccount<out T>
    {
        T AddBalance(int balance);
    }
}
