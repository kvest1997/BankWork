using HM11._6.Models.PersonalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HM11._6.Models.Clients
{
    /// <summary>
    /// Для вывода информации о конкретном клиенте
    /// </summary>
    public class ClientInfo : Client
    {
        public string StringPassportData => PassportSerie + "-" + PassportNumber;
        public string FIO => Surname + " " + FirstName + " " + LastName;
        public string PassportSerie { get; set; }
        public string PassportNumber { get; set; }

        public ClientInfo() { }

        public ClientInfo(Client client):base(client.NumberPhone,client.PassportData,client.FirstName,client.Surname,client.LastName)
        {
            Id = client.Id;
        }
    }
}
