using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Test_Resume.Context;
using Test_Resume.Interface;
using Test_Resume.Model;
using Test_Resume.Model.Enums;
using Test_Resume.Model.Model;
using Test_Resume.ViewModel;

namespace  Test_Resume.ViewModel
{
    public class GraphManagerViewModel : ViewModelBase
    {

        public GraphManagerViewModel(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
            ElementGraphs.CollectionChanged += ElementGraphs_CollectionChanged;
        }

        public Window OneElementWindow { get; set; }
        public OneElementWindowViewModel OneElementWindowViewModel { get; set; }

        
      
        private void ElementGraphs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("ElementGraphs"); 
        }

        public DatabaseContext DatabaseContext { get; set; }
        public List<ElementGraph> Elements { get => DatabaseContext.ElementGraphs.Include(x => x.Childs).ToList().Where(x => x.DominateLevel == DominateLevel.Level1).ToList(); }
        public ObservableCollection<ElementGraph> ElementGraphs { get => new ObservableCollection<ElementGraph>(Elements);  }

       
        public int MininalYear { get
            { if (ElementGraphs.Where(x => x.StartTime.HasValue).Count()>0)
                    return ElementGraphs.Where(x => x.StartTime.HasValue).Select(x => x.StartTime.Value.Year).Min();
                return  2019;
            }
        }

        public int MaxYear
        {
            get
            {
                if (ElementGraphs.Where(x => x.EndTime.HasValue).Count() > 0)
                    return ElementGraphs.Where(x => x.EndTime.HasValue).Select(x => x.EndTime.Value.Year).Max();
                return 2020;
            }
        }
        #region Commands
        RelayCommand _edingCommand;
        public RelayCommand EdingCommand
        {
            get
            {
                if (_edingCommand == null)
                    _edingCommand = new RelayCommand(ExecuteEdingCommand, CanExecuteEdingCommand);
                return _edingCommand;
            }

        }
        public void ExecuteEdingCommand(object parameter)
        {
            if((parameter) is  IElementGraph)
            {
                OneElementWindowViewModel.EditElementPageViewModel.CurrentElementGraph_Eding = (ElementGraph)(parameter);
                OneElementWindowViewModel.SetEdingPage();
                OneElementWindow = new OneElementWindow() { DataContext = OneElementWindowViewModel };
                OneElementWindow.ShowDialog();
            }
            else {
                OneElementWindowViewModel.SetAddElementPage();
                OneElementWindowViewModel.AddElementPageViewModel.AddFirstLevelElement = true;
                OneElementWindow = new OneElementWindow() { DataContext = OneElementWindowViewModel };
                OneElementWindow.ShowDialog();
            }
        }

        public bool CanExecuteEdingCommand(object parameter) => true;

        public void Update()
        {
            OnPropertyChanged("Elements");
            OnPropertyChanged("ElementGraphs");
            OnPropertyChanged("MininalYear");
            OnPropertyChanged("MaxYear");
        }

        #endregion



    }
}
