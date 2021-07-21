using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DTSBox_WPF.Common
{
    /// <summary>
    /// Converts Null images for better performance in WPF Imagebinding
    /// </summary>
    public class NullImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DependencyProperty.UnsetValue;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
