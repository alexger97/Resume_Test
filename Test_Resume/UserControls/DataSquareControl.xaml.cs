using System;
using System.Collections.Generic;
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
using Test_Resume.Model.Enums;

namespace Test_Resume.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DataSquareControl.xaml
    /// </summary>
    public partial class DataSquareControl : UserControl
    {
        public DataSquareControl()
        {
            InitializeComponent();

        }
        
        static DataSquareControl()
        { 
            TypeOfVisualPropert = DependencyProperty.Register("TypeOfVisual", typeof(TypeOfVisual), typeof(DataSquareControl), new PropertyMetadata(null));
            PlaceProperty= DependencyProperty.Register("Place", typeof(short), typeof(DataSquareControl), new PropertyMetadata(null));
        }
        public static readonly DependencyProperty TypeOfVisualPropert;
        public static readonly DependencyProperty BrushProperty;
        public static readonly DependencyProperty PlaceProperty;
        public TypeOfVisual TypeOfVisual
        {
            get
            {
                return (TypeOfVisual)GetValue(TypeOfVisualPropert);
            }
            set
            {
                SetValue(TypeOfVisualPropert, value);
            }
        }
        public short Place
        {
            get
            {
                return (short)GetValue(PlaceProperty);
            }
            set
            {
                SetValue(PlaceProperty, value);
            }
        }

        
        

    }
}
