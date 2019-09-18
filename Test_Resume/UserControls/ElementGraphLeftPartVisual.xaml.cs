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
using Test_Resume.Model.Enums;
using Test_Resume.Model.Model;

namespace Test_Resume.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ElementGraphVisual.xaml
    /// </summary>
    public partial class ElementGraphLeftPartVisual : UserControl
    {
        public ElementGraphLeftPartVisual()=> InitializeComponent();
        


       
        static ElementGraphLeftPartVisual()
        {
            ItemProperty = DependencyProperty.Register("Item", typeof(IElementGraph), typeof(ElementGraphLeftPartVisual), new FrameworkPropertyMetadata(null));
       
            ChildsVisabilityProperty = DependencyProperty.Register("ChildsVisability", typeof(bool), typeof(ElementGraphLeftPartVisual), new PropertyMetadata(null));
            EditItemProperty = DependencyProperty.Register("EditItem", typeof(ICommand), typeof(ElementGraphLeftPartVisual), new PropertyMetadata(null));
        }

       
         public static readonly DependencyProperty ChildsVisabilityProperty;
        public static readonly DependencyProperty ItemProperty;
        public static readonly DependencyProperty EditItemProperty;

        public bool ChildsVisability
         {
             get=>(bool)GetValue(ChildsVisabilityProperty);
             set { SetValue(ChildsVisabilityProperty, value); }
         }


            
        public IElementGraph Item
        {
            get => (IElementGraph)GetValue(ItemProperty);
            set { SetValue(ItemProperty, value); }
        }

        public ICommand EditItem
        {
            get => (ICommand)GetValue(EditItemProperty);
            set { SetValue(EditItemProperty, value); }
        }


        

      

    }
}
