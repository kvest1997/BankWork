using HM11._6.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace HM11._6.Models.Infastructure
{
    /// <summary>
    /// Конвертор для валидности данных
    /// </summary>
    public class InputValueHighlightingConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is InputValueHighlightingEnum mode))
            {
                return null;
            }

            switch (mode)
            {
                case InputValueHighlightingEnum.Default: new SolidColorBrush((Color)ColorConverter.ConvertFromString("#844eff"));
                    break;
                case InputValueHighlightingEnum.Disable: new SolidColorBrush(Colors.Silver);
                    break;
                case InputValueHighlightingEnum.Error: new SolidColorBrush(Colors.Red);
                    break;
            }

            return mode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
