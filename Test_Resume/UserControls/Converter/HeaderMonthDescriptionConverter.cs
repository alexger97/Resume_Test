using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Test_Resume.UserControls.Converter
{
    class HeaderMonthDescriptionConverter : IMultiValueConverter
    {
        
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
          if (values[1] is int)
            {

            
            string month = "";
            string year = "";  
            switch ((int)values[1])
            {
                case 1: month = "Январь"; break;
                case 2: month = "Февраль"; break;
                case 3: month = "Март"; break;
                case 4: month = "Апрель"; break;
                case 5: month = "Май"; break;
                case 6: month = "Июнь"; break;
                case 7: month = "Июль"; break;
                case 8: month = "Август"; break;
                case 9: month = "Сентябрь"; break;
                case 10: month = "Октябрь"; break;
                case 11: month = "Ноябрь"; break;
                case 12: month = "Декабрь"; break;
            }
            if (values[0] != null) { year = System.Convert.ToInt32(values[0]).ToString(); } 
            return month + " "+ year;
            } return "";
        }

     

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
