using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DTSBox_WPF.Common
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Do some stuff
            return null;
        }
    }
}