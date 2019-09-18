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
    class TypeOfVisualFromDateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] != null)
            {
                var StartTime = (DateTime)values[0];
                var EndTime = (DateTime)values[1];
                var Year = (int)values[2];
                var interval = (string)values[3];
                var Month = int.Parse(interval[2].ToString() + interval[3].ToString());

                if (Year < EndTime.Year && Year > StartTime.Year)
                {
                    return TypeOfVisual.activ;
                }
                else
                {
                    if (Year == StartTime.Year && Year == EndTime.Year)
                    {
                        if (Month < EndTime.Month && Month > StartTime.Month)
                        {
                            return TypeOfVisual.activ;
                        }

                       if(Month==StartTime.Month&&Month==EndTime.Month)
                          {
                              if (interval[0].Equals('A'))
                              {
                                  if (StartTime.Day <= 10)
                                  {
                                    return TypeOfVisual.activ;
                                }
                              }
                            if (interval[0].Equals('B'))
                            {
                                if ((StartTime.Day <= 20)&& EndTime.Day > 10)
                                {
                                    return TypeOfVisual.activ;
                                }
                            }

                            if (interval[0].Equals('C'))
                            {
                                if ((StartTime.Day > 20)) 
                                {
                                    return TypeOfVisual.activ;
                                }
                            }

                        }
                        else
                        {
                            if (Month == EndTime.Month)
                            { if (interval[0].Equals('A')) { return TypeOfVisual.activ; } }
                            if (Month == EndTime.Month)
                            {
                               if (interval[0].Equals('B') && EndTime.Day <= 20 && EndTime.Day > 10)
                                { return TypeOfVisual.activ; }
                            }
                            if (Month == EndTime.Month)
                            { if (interval[0].Equals('C') && EndTime.Day <= 31 && EndTime.Day > 20) { return TypeOfVisual.activ; } }

                            if (Month == StartTime.Month)
                            { if (interval[0].Equals('A') && StartTime.Day <= 10) { return TypeOfVisual.activ; } }
                            if (Month == StartTime.Month)
                            {
                                if (interval[0].Equals('B') && StartTime.Day <= 20) { return TypeOfVisual.activ; }
                            }
                            if (Month == StartTime.Month)
                            {
                                if (interval[0].Equals('C') && StartTime.Day <= 31) { return TypeOfVisual.activ; }
                            }

                        }

                        

                    }
                    else
                    {
                        if (Year == StartTime.Year)
                        {
                            if (Month > StartTime.Month) return TypeOfVisual.activ;
                            if (Month == StartTime.Month)
                            {
                                if (interval[0].Equals('A') && StartTime.Day <= 10) { return TypeOfVisual.activ; }
                                if (interval[0].Equals('B') && StartTime.Day <= 20) { return TypeOfVisual.activ; }
                                if (interval[0].Equals('C') && StartTime.Day <= 31) { return TypeOfVisual.activ; }
                            }
                            return TypeOfVisual.nonactive;

                        }
                        if (Year == EndTime.Year)
                        {
                            if (Month < EndTime.Month) return TypeOfVisual.activ;

                            if (Month == EndTime.Month)
                            {
                                if (interval[0].Equals('A')) { return TypeOfVisual.activ; }
                                if (interval[0].Equals('B') && EndTime.Day >10) { return TypeOfVisual.activ; }
                                if (interval[0].Equals('C') && EndTime.Day <= 31 && EndTime.Day>20) { return TypeOfVisual.activ; }
                            }
                            return TypeOfVisual.nonactive;

                        }
                    }
                }
              return TypeOfVisual.nonactive;
            }
            return TypeOfVisual.nonactive;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
