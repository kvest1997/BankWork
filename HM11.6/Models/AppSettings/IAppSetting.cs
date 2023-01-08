using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.AppSettings
{
    public interface IAppSetting
    {
        void Save(AppSetting appSetting);
        AppSetting Load();
    }
}
