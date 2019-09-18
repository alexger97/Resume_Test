using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для HeaderData.xaml
    /// </summary>
    public partial class HeaderData : UserControl
    {
        public HeaderData()=> InitializeComponent();
        

        static HeaderData()
        {
        StartYearProperty = DependencyProperty.Register("StartYear", typeof(int), typeof(HeaderData), new FrameworkPropertyMetadata( null ));
         EndYearProperty = DependencyProperty.Register("EndYear", typeof(int), typeof(HeaderData), new FrameworkPropertyMetadata(null));
        }

        public static readonly DependencyProperty StartYearProperty;
        public static readonly DependencyProperty EndYearProperty;

        public int StartYear
        {
            get => (int)GetValue(StartYearProperty);
            set { SetValue(StartYearProperty, value); }
        }

        public int EndYear
        {
            get => (int)GetValue(EndYearProperty);
            set { SetValue(EndYearProperty, value);  
            }
        }

        public ObservableCollection<int> ListYears { get; set; }
        public List<int> GetActualYears(int StartYeat, int EndYear)
        {
            var Years = new List<int>();
            for (int i = StartYeat; i < EndYear; i++) Years.Add(i);
            return Years;
        }


        
    }
}
