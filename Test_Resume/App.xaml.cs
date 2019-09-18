using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Test_Resume.Context;
using Test_Resume.Model;
using Test_Resume.Model.Enums;
using Test_Resume.ViewModel;

namespace Test_Resume
{
    
    public partial class App : Application
    {
        public GraphManagerViewModel GraphManagerViewModel;

        
            
        protected override void OnStartup(StartupEventArgs e)
        {
             DatabaseContext DbContext = new DatabaseContext();

             //Сборка
             GraphManagerViewModel = new GraphManagerViewModel(DbContext);

              EditElementPageViewModel EditElementPageViewModel = new EditElementPageViewModel(GraphManagerViewModel);
              AddElementPageViewModel AddElementPageViewModel = new AddElementPageViewModel(GraphManagerViewModel);
              Page AddElementPage = new AddElementPage { DataContext = AddElementPageViewModel };
              Page EditElementPage = new EditElementPage { DataContext = EditElementPageViewModel };

              Page DeleteAdvertisment = new DeleteAdvertisment();

              OneElementWindowViewModel OneElementWindowViewModel = new OneElementWindowViewModel(EditElementPage, AddElementPage, DeleteAdvertisment);

              AddElementPageViewModel.OneElementWindowViewModel = OneElementWindowViewModel;
              EditElementPageViewModel.OneElementWindowViewModel = OneElementWindowViewModel;

              GraphManagerViewModel.OneElementWindowViewModel = OneElementWindowViewModel;
              Window window = new GrapfManagerWindow() { DataContext = GraphManagerViewModel };

              window.Show();  
         

        } }
    

    

   
}
