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
    /// Логика взаимодействия для HeaderYearControl.xaml
    /// </summary>
    public partial class HeaderYearControl : UserControl
    {
        public HeaderYearControl()
        {
            InitializeComponent();
        }

        static HeaderYearControl()
        {
            CurrentYearProperty = DependencyProperty.Register("CurrentYear", typeof(int), typeof(HeaderYearControl), new PropertyMetadata(null));
        }

        public static readonly DependencyProperty CurrentYearProperty;

        public int CurrentYear
        {
            get
            {
                return (int)GetValue(CurrentYearProperty);
            }
            set
            {
                SetValue(CurrentYearProperty, value);
            }
        }


    }


}
