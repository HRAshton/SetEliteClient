using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SetElite.Client.Converters
{
    public class ParameterNameStatusConverter : IValueConverter
    {
        public object Convert(object isEnabled, Type targetType, object parameterName, CultureInfo culture)
        {
            if (!(isEnabled is bool isParameterEnabled))
                return "Пример параметра";

            var str = isParameterEnabled ? "Включено" : "Отключено";

            return $"{parameterName} ({str})";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("Только в одну сторону.");
        }
    }
}