using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using Test_Resume.Model.Enums;

namespace Test_Resume.UserControls.Converter
{
    class DominateLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
             

            if(parameter==null)
            {
                string level = "";
                switch ((DominateLevel)(value))
                {
                    case DominateLevel.Level1: level = "Уровень 1"; break;
                    case DominateLevel.Level2: level = "Уровень 2"; break;
                    case DominateLevel.Level3: level = "Уровень 3"; break;
                    case DominateLevel.Level4: level = "Уровень 4"; break;
                    case DominateLevel.Level5: level = "Технологическая карта"; break;
                }
                return level;
            }
            else
            {

            
            if(System.Convert.ToInt32(parameter)==1)
            {
                if ((DominateLevel)(value) == DominateLevel.Level5)
                {
                    return Visibility.Collapsed;
                }
                return Visibility.Visible;
            }

            if (System.Convert.ToInt32(parameter) == 2)
            {
                if ((DominateLevel)(value) == DominateLevel.Level5)
                {
                    return Visibility.Visible;
                }
                    if ((DominateLevel)(value) == DominateLevel.Level1)
                    {
                        return Visibility.Collapsed;
                    }
                    return Visibility.Collapsed;
            }
                }  return new NotSupportedException();
            
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return  new NotSupportedException();
        }
    }
}
