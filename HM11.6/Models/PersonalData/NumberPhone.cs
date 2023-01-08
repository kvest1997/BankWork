using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace HM11._6.Models.PersonalData
{
    /// <summary>
    /// Модель номера телефона
    /// </summary>
    public class NumberPhone
    {
        private string _phone;
        
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public NumberPhone()
        {
            
        }

        public NumberPhone(string number)
        {
            SetNumber(number);
        }
        /// <summary>
        /// Проверка валидности телефона
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string number)
        {
            var result = Regex.Match(number, @"\d{9}$").Success;
            return result;
        }

        /// <summary>
        /// Установка номера телефона
        /// </summary>
        /// <param name="number"></param>
        private void SetNumber(string number)
        {
            CheckNumber(number);
            _phone = number;
        }

        /// <summary>
        /// Проверка строки на пробелы и на пустуб строку
        /// </summary>
        /// <param name="number"></param>
        /// <exception cref="ArgumentException"></exception>
        private void CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException($"Номер \"{nameof(number)}\" не может быть пустым");
            }

            if (!IsPhoneNumber(number))
            {
                throw new ArgumentException($"Строка \"{nameof(number)}\" не является номером телефона");
            }
        }

        public override string ToString()
        {
            return $"{Phone}";
        }
    }
}
