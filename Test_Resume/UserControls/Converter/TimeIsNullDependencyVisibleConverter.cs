using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Test_Resume.UserControls.Converter
{
    class TimeIsNullDependencyVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if(System.Convert.ToInt32(parameter)!=1)
            { 
            var time = ((DateTime?)(value));
            if (time.HasValue) return time.Value;
            return "♯";}
            else
            {
                if (value == null) return Visibility.Collapsed;return Visibility.Visible;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
