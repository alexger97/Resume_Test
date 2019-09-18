using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Test_Resume.UserControls.Converter
{
    class ItemsHeaderDataConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[0] is int &&values[1] is int )
            {

           
            var y1 = System.Convert.ToInt32(values[0]);
            var y2 = System.Convert.ToInt32(values[1]);
            return  GetActualYears(y1, y2);
            } return new List<int>();
        }
        public List<int> GetActualYears(int StartYeat, int EndYear)
        {
            var Years = new List<int>();
            for (int i = StartYeat; i <= EndYear; i++) Years.Add(i);
            return Years;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
