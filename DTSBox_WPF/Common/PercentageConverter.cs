using System;
using System.Windows.Data;

namespace DTSBox_WPF.Common
{
    /// <summary>
    /// Converting value to percentage for WPF Progressbars
    /// </summary>
    public class PercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int percentage = System.Convert.ToInt16(Math.Round(System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter), 0));
            return percentage > 100 ? 100 : percentage < 0 ? 0 : percentage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Do some stuff
            return null;
        }
    }
}
