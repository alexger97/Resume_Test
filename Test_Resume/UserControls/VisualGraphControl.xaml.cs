using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Test_Resume.Interface;
using Test_Resume.Model;
using Test_Resume.Model.Enums;
using Test_Resume.Model.Model;
using Test_Resume.ViewModel;

namespace Test_Resume.UserControls
{
    /// <summary>
    /// Логика взаимодействия для VisualGraphControl.xaml
    /// </summary>
    public partial class VisualGraphControl : UserControl
    {
        public VisualGraphControl()=> InitializeComponent();
          

        public static readonly DependencyProperty SourceProperty;
        public static readonly DependencyProperty StartYearProperty;
        public static readonly DependencyProperty EndYearProperty;
        public static readonly DependencyProperty ExternalCommandProperty;
        static VisualGraphControl()
        {
            SourceProperty = DependencyProperty.Register("Source", typeof(IEnumerable<IElementGraph>), typeof(VisualGraphControl), new FrameworkPropertyMetadata(null));
            StartYearProperty = DependencyProperty.Register("StartYear", typeof(int), typeof(VisualGraphControl), new FrameworkPropertyMetadata(null));
            EndYearProperty = DependencyProperty.Register("EndYear", typeof(int), typeof(VisualGraphControl), new FrameworkPropertyMetadata(null));
            ExternalCommandProperty = DependencyProperty.Register("ExternalCommand", typeof(ICommand), typeof(VisualGraphControl), new FrameworkPropertyMetadata(null));

        }

        public ObservableCollection<IElementGraph> Source
        {
            get => (ObservableCollection<IElementGraph>)GetValue(SourceProperty);
            set { SetValue(SourceProperty, value); }
        }

        public int StartYear
        {
            get => (int)GetValue(StartYearProperty);
            set { SetValue(StartYearProperty, value);   }
        }

        public int EndYear
        {
            get => (int)GetValue(EndYearProperty);
            set { SetValue(EndYearProperty, value); }
        }

        public ICommand ExternalCommand
        {
            get => (ICommand)GetValue(ExternalCommandProperty);
            set { SetValue(ExternalCommandProperty, value); }
        }

        public IEnumerable<int> ListYears { get {   return GetActualYears(StartYear, EndYear); }  }

        
        public List<int> GetActualYears(int StartYeat, int EndYear)
        {
            var Years = new List<int>();
            for (int i = StartYeat; i <= EndYear; i++) Years.Add(i);
            return Years;
        }

    }
}
