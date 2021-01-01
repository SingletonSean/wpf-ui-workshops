using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace HoldSubmitButtonControl.Converters
{
    public class DurationSecondsSubtractionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Duration duration && double.TryParse(parameter.ToString(), out double seconds))
            {
                return duration.Subtract(TimeSpan.FromSeconds(seconds));
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
