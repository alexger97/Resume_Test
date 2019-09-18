using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
using Test_Resume.Model.Model;

namespace Test_Resume.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ElementGraphVisual.xaml
    /// </summary>
    public partial class ElementGraphRigthPartVisual : UserControl
    {
        public ElementGraphRigthPartVisual()=> InitializeComponent();
         
        
        static ElementGraphRigthPartVisual()
        {
            ItemProperty = DependencyProperty.Register("Item", typeof(IElementGraph), typeof(ElementGraphRigthPartVisual), new FrameworkPropertyMetadata(null));
            CurrentYearProperty = DependencyProperty.Register("CurrentYear", typeof(int), typeof(ElementGraphRigthPartVisual), new FrameworkPropertyMetadata(null));
        }
    
        public static readonly DependencyProperty ItemProperty;
        public static readonly DependencyProperty  CurrentYearProperty;

        #region Property
        public IElementGraph Item
        {
            get => (IElementGraph)GetValue(ItemProperty);
            set { SetValue(ItemProperty, value); }
        }

        public int CurrentYear
        {
            get => (int)GetValue(CurrentYearProperty);
            set { SetValue(CurrentYearProperty, value); }
        }
        public DateTime StartTime
        {
            get => (DateTime)Item.StartTime;
        }
        public DateTime EndTime
        {
            get => (DateTime)Item.EndTime;
        }
        #endregion


        string GetIntervalName(string Name )
        {
            string month = "";
            switch ((int.Parse((Name[2].ToString() + Name[3].ToString()))))
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
            string description="";
            if (Name[0].Equals('A')) description = "C первого по десятое число";
            if (Name[0].Equals('B')) description = "C одиннадцатого по двадцатое число";
            if (Name[0].Equals('C')) description = "C  двадцать первого числа";

            return $"Месяц: {month}, промежуток: {description}";
        }

        private void DataSquareControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var ds = (DataSquareControl)(sender);
         
            MessageBox.Show($"{GetIntervalName(ds.Name)} \nНазвание уровня: {Item.Name}","Описание уровня",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
}
