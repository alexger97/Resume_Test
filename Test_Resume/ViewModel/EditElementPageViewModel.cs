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
    public class EditElementPageViewModel : ViewModelBase
    {
        public EditElementPageViewModel(GraphManagerViewModel graphManagerViewModel)
        {
            GraphManagerViewModel = graphManagerViewModel;
        }

        public OneElementWindowViewModel OneElementWindowViewModel { get; set; }
   
        void Reset()
        {
            ElementName = CurrentElementGraph_Eding.Name;
            if(CurrentElementGraph_Eding.StartTime.HasValue)
                StartTime_Eding = CurrentElementGraph_Eding.StartTime.Value.Date;
            if (CurrentElementGraph_Eding.EndTime.HasValue)
                EndTime_Eding = CurrentElementGraph_Eding.EndTime;
        }

        public GraphManagerViewModel GraphManagerViewModel { get; set; }


      
        private ElementGraph currentElementGraph;
        public ElementGraph CurrentElementGraph_Eding { get => currentElementGraph; set { currentElementGraph = value; Reset(); OnPropertyChanged("CurrentElementGraph_Eding"); } }

        private string elementName;
        public string ElementName { get => elementName; set { elementName = value; OnPropertyChanged("ElementName"); } }

        private DateTime? startTime;
        public DateTime? StartTime_Eding { get => startTime; set { startTime = value; OnPropertyChanged("StartTime_Eding"); } }

        private DateTime? endTime;
        public DateTime? EndTime_Eding { get => endTime; set { endTime = value; OnPropertyChanged("EndTime_Eding"); } }

        private bool isEdit;
        public bool IsEdit { get => isEdit; set { isEdit = value; if (value == false) Reset(); OnPropertyChanged("IsEdit"); } }


        private void ChangeDates(IElementGraph Item, TimeSpan? startSpan, TimeSpan? endSpan)
        {
           Item.StartTime = Item.StartTime.Value.Add(startSpan.Value);
           Item.EndTime = Item.EndTime.Value.Add(endSpan.Value);
           GraphManagerViewModel.Update();
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
            TimeSpan Enddatechange;
            var Startdatechange = StartTime_Eding - CurrentElementGraph_Eding.StartTime;
            if (CurrentElementGraph_Eding.DominateLevel != DominateLevel.Level5)
                Enddatechange = Startdatechange.Value;
            else Enddatechange = EndTime_Eding.Value - CurrentElementGraph_Eding.EndTime.Value;


            ElementGraph elementGraph = CurrentElementGraph_Eding;

            if (elementGraph.DominateLevel != DominateLevel.Level5)
            {
                foreach (var el in elementGraph.Childs)
                {

                    if (el.DominateLevel != DominateLevel.Level5)
                    {
                        foreach (var el2 in el.Childs)
                        {
                            if (el2.DominateLevel != DominateLevel.Level5)
                            {
                                foreach (var el3 in el2.Childs)
                                {
                                    if (el3.DominateLevel != DominateLevel.Level5)
                                    {
                                        foreach (var el4 in el3.Childs)
                                        {
                                            if (el4.DominateLevel != DominateLevel.Level5)
                                            {

                                            }
                                            else ChangeDates(el4, Startdatechange, Enddatechange);
                                        }
                                    }
                                    else ChangeDates(el3, Startdatechange, Enddatechange);
                                }
                            }
                            else ChangeDates(el2, Startdatechange, Enddatechange);
                        }
                    }
                    else ChangeDates(el, Startdatechange, Enddatechange);
                }
            }
            else ChangeDates(elementGraph, Startdatechange, Enddatechange);

            GraphManagerViewModel.DatabaseContext.SaveChanges();
            GraphManagerViewModel.Update();
        }
    

        public bool CanExecuteEdingCommand(object parameter)
        {
            if (StartTime_Eding < EndTime_Eding) return true;
            return false;
        }


        RelayCommand _AddChildCommand;
        public RelayCommand AddChildCommand
        {
            get
            {
                if (_AddChildCommand == null)
                    _AddChildCommand = new RelayCommand(ExecuteAddChildCommand, CanExecuteAddChildCommand);
                return _AddChildCommand;
            }

        }
        public void ExecuteAddChildCommand(object parameter)
        {
            OneElementWindowViewModel.AddElementPageViewModel.Clear();
            OneElementWindowViewModel.AddElementPageViewModel.Father = CurrentElementGraph_Eding;
            OneElementWindowViewModel.SetAddElementPage();


        }

        public bool CanExecuteAddChildCommand(object parameter)
        {
            if(CurrentElementGraph_Eding!=null)
           if (CurrentElementGraph_Eding.DominateLevel != DominateLevel.Level5)
            return true; return false;
        }

        RelayCommand _DeleteElementCommand;
        public RelayCommand DeleteElementCommand
        {
            get
            {
                if (_DeleteElementCommand == null)
                    _DeleteElementCommand = new RelayCommand(ExecuteDeleteElementCommand, CanExecuteDeleteElementCommand);
                return _DeleteElementCommand;
            }

        }
        public void ExecuteDeleteElementCommand(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Подтвердите удаление элемента. Все дочерние элементы будут удалены!", "Удаление элемента", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                GraphManagerViewModel.DatabaseContext.ElementGraphs.Remove(GraphManagerViewModel.DatabaseContext.ElementGraphs.Find(CurrentElementGraph_Eding.Id));
                GraphManagerViewModel.DatabaseContext.SaveChanges();
                GraphManagerViewModel.Update();
                OneElementWindowViewModel.SetDeleteAdvertismentPage();
            }
            
        }

        public bool CanExecuteDeleteElementCommand(object parameter)
        {
             return true; 
        }

        #endregion
    }
}
