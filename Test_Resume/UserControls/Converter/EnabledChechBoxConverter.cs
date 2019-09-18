using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Test_Resume.Interface;
using Test_Resume.Model;
using Test_Resume.Model.Enums;

namespace Test_Resume.UserControls.Converter
{
    class EnabledChechBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is List<ElementGraph>)
            {
                if (((List<ElementGraph>)(value)).Count > 0) return true;
                return false;
            }
            return   false;
                
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
