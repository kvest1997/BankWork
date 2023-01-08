using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Worker
{
    /// <summary>
    /// Модель для прав доступа
    /// </summary>
    public class UserAccess
    {
        public CommnadsAccess Commands;
        public EditFieldAccess EditAccess;
        public UserAccess(CommnadsAccess command, EditFieldAccess editAccess)
        {
            this.EditAccess = editAccess;
            this.Commands = command;
        }
    }


    public struct CommnadsAccess
    {
        public bool AddClient;
        public bool DelClient;
        public bool EditClient;
        public bool AccountClient;
    }

    public struct EditFieldAccess
    {
        public bool FirstName;
        public bool Surname;
        public bool LastName;
        public bool PhoneNumber;
        public bool PassportData;
        public bool Account;
    }
}
