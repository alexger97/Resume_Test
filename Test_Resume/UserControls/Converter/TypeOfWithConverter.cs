using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Test_Resume.Model.Enums;

namespace Test_Resume.UserControls.Converter
{
    class TypeOfWithConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is DominateLevel)
            {

            
            switch ((DominateLevel)(value))
            {
                case DominateLevel.Level1:return new System.Windows.Thickness(2, 0, 0, 0);
                case DominateLevel.Level2: return new System.Windows.Thickness(8, 0, 0, 0);
                case DominateLevel.Level3: return new System.Windows.Thickness(14, 0, 0, 0);
                case DominateLevel.Level4: return new System.Windows.Thickness(20, 0, 0, 0);
                case DominateLevel.Level5: return new System.Windows.Thickness(26, 0, 0, 0);
            }
            }
            return new  System.Windows.Thickness(0, 0, 0, 0);
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
