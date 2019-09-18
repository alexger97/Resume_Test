using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test_Resume.Interface;
using Test_Resume.Model;
using Test_Resume.Model.Enums;
using Test_Resume.Model.Model;

namespace Test_Resume.ViewModel
{
  public  class AddElementPageViewModel:ViewModelBase
    {
        public AddElementPageViewModel(GraphManagerViewModel graphManagerViewModel )
        {
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            GraphManagerViewModel = graphManagerViewModel;
            Name = "";

        }

        #region Property
        private bool addFirstLevelElement;
        public bool AddFirstLevelElement { get => addFirstLevelElement;set { addFirstLevelElement = value;OnPropertyChanged("AddFirstLevelElement"); OnPropertyChanged("DominateLevelForNewItem"); } }
        public OneElementWindowViewModel OneElementWindowViewModel { get; set; }
        GraphManagerViewModel GraphManagerViewModel { get; set; }

        
        private IElementGraph father;
        public IElementGraph Father { get => father; set { father = value;OnPropertyChanged("Father"); OnPropertyChanged("DominateLevelForNewItem"); } }

        private string name;
        public string Name { get => name; set { name = value; OnPropertyChanged("Name"); } }

        private DateTime startTime;
        public DateTime StartTime { get => startTime; set { startTime = value;OnPropertyChanged("StartTime"); } }

        private DateTime endTime;
        public DateTime EndTime { get => endTime; set { endTime = value; OnPropertyChanged("EndTime"); } }


        public DominateLevel DominateLevelForNewItem { get {
                if (AddFirstLevelElement) return DominateLevel.Level1;
                if (Father!=null) return 
                    (DominateLevel)((int)Father.DominateLevel + 1);
                return DominateLevel.Level1; } }

        #endregion

        #region Commands
        RelayCommand _AddElementCommand;
        public RelayCommand AddElementCommand
        {
            get
            {
                if (_AddElementCommand == null)
                    _AddElementCommand = new RelayCommand(ExecuteEdingCommand, CanExecuteEdingCommand);
                return _AddElementCommand;
            }

        }
        public void ExecuteEdingCommand(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Подтвердите добавление нового элемента", "Добавление нового элемента", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                ElementGraph Item;
                if (DominateLevelForNewItem == DominateLevel.Level5)
                    Item = new ElementGraph() { Name = Name, DominateLevel = DominateLevelForNewItem, EndTime = EndTime, StartTime = StartTime };
                else  Item = new ElementGraph() { DominateLevel = DominateLevelForNewItem, Name = Name, Childs = new List<ElementGraph>() };

                GraphManagerViewModel.DatabaseContext.ElementGraphs.Add(Item);
                if (DominateLevelForNewItem != DominateLevel.Level1)
                {
                    GraphManagerViewModel.DatabaseContext.ElementGraphs.Include(x=>x.Childs).First(x => x.Id == Father.Id).Childs.Add(Item);
                }
               
                GraphManagerViewModel.DatabaseContext.SaveChanges();
            GraphManagerViewModel.Update();
                 
                Clear();

                if (DominateLevelForNewItem == DominateLevel.Level1) OneElementWindowViewModel.EditElementPageViewModel.CurrentElementGraph_Eding = Item;
                OneElementWindowViewModel.SetEdingPage();
             }        
        }

        public bool CanExecuteEdingCommand(object parameter)
        {
          if(!Name.Equals("")&&StartTime<=EndTime)  return true;
            return false;
        }




        RelayCommand _BackCommand;
        public RelayCommand BackCommand
        {
            get
            {
                if (_BackCommand == null)
                    _BackCommand = new RelayCommand(ExecuteBackCommand, CanExecuteBackCommand);
                return _BackCommand;
            }

        }
        public void ExecuteBackCommand(object parameter)
        {
            OneElementWindowViewModel.SetEdingPage();
        }

        public bool CanExecuteBackCommand(object parameter)
        {
            if (AddFirstLevelElement) return false; return true;
        }
        #endregion 



        public void Clear()
        {
            Father = null; Name = ""; StartTime = EndTime = DateTime.Now;
            EndTime = StartTime.AddDays(1);
            AddFirstLevelElement = false;
        }




    }
}
