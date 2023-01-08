using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.PersonalData
{
    /// <summary>
    /// Модель первичных данных о клиенте
    /// </summary>
    public class Person
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }

        public Person()
        {

        }

        public Person(string firstName, string surname, string lastName)
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.LastName = lastName;
        }
    }
}
