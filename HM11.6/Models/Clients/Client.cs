using HM11._6.Models.PersonalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.Clients
{
    /// <summary>
    /// Общая модель клиента
    /// </summary>
    public class Client : Person
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public NumberPhone NumberPhone { get; set; }
        public PassportData PassportData { get; set; }

        public Client() { }

        public Client(NumberPhone phone, PassportData passport, string firstName, string surname, string lastName=""):base(firstName,surname,lastName)
        {
            this.NumberPhone = phone;
            this.PassportData = passport;
        }
    }
}