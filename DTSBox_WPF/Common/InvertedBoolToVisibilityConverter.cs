using System;
using System.Globalization;
using System.Windows.Data;

namespace DTSBox_WPF.Common
{
    public class InvertedBoolToVisibilityConverter : IValueConverter
    {
        private BoolToVisibilityConverter converter = new BoolToVisibilityConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return converter.Convert(!(bool)value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return converter.ConvertBack(!(bool)value, targetType, parameter, culture);
        }
    }
}
