using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM11._6.Models.PersonalData
{
    /// <summary>
    /// Модель паспортных данных
    /// </summary>
    public class PassportData
    {

        private const int MaxSerialPassportValue = 9999;
        private const int MinSerialPassportValue = 1;

        private const int MaxNumberPassportValue = 999999;
        private const int MinNumberPassportValue = 1;

        public string SerialPassport { get; set; }
        public string NumberPassport { get; set; }

        public PassportData()
        {

        }

        public PassportData(string serial, string number)
        {
            this.NumberPassport = number;
            this.SerialPassport = serial;   
        }

        /// <summary>
        /// Проверка валидности номера паспорта
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {

            if (!int.TryParse(value, out int number))
            {
                return false;
            }

            if (number < MinNumberPassportValue || number > MaxNumberPassportValue)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверка валидности серии паспорта
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSerial(string value)
        {

            if (!int.TryParse(value, out int serial))
            {
                return false;
            }

            if (serial < MinSerialPassportValue || serial> MaxSerialPassportValue)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{SerialPassport}-{NumberPassport}";
        }
    }
}
