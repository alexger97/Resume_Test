using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Test_Resume.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HeaderMonth.xaml
    /// </summary>
    public partial class HeaderMonth : UserControl
    {
        public HeaderMonth()=>InitializeComponent();
        

        static HeaderMonth()
        {
            YearProperty=DependencyProperty.Register("Year", typeof(int), typeof(HeaderMonth), new PropertyMetadata(null));
            MonthProperty = DependencyProperty.Register("Month", typeof(int), typeof(HeaderMonth), new PropertyMetadata(null));
        }
        public static readonly DependencyProperty YearProperty;
        public static readonly DependencyProperty MonthProperty;
        public int Year
        {
            get
            {
                return (int)GetValue(YearProperty);
            }
            set
            {
                SetValue(YearProperty, value);
            }
        }

        public int Month
        {
            get
            {
                return (int)GetValue(MonthProperty);
            }
            set
            {
                SetValue(MonthProperty, value);
            }
        }
    }
}
