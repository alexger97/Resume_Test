using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Test_Resume.Model;

namespace Test_Resume.ViewModel
{
   public class OneElementWindowViewModel:ViewModelBase
    {
        public OneElementWindowViewModel(Page EditElementPage, Page AddElementPage,Page DeleteAdvertisment)
        {
            this.EditElementPage = EditElementPage;
            this.AddElementPage = AddElementPage;
            this.DeleteAdvertisment = DeleteAdvertisment;

            AddElementPageViewModel = (AddElementPageViewModel)AddElementPage.DataContext;
            EditElementPageViewModel = (EditElementPageViewModel)EditElementPage.DataContext;
            
            SetEdingPage();
        }

        public Page EditElementPage { get; set; }
        public Page AddElementPage { get; set; }

        public Page DeleteAdvertisment { get; set; }

        public AddElementPageViewModel AddElementPageViewModel { get; set; }

        public EditElementPageViewModel EditElementPageViewModel { get; set; }


        private Page currentPage;

        public Page CurrentPage { get => currentPage; set { currentPage = value; OnPropertyChanged("CurrentPage"); } }


        public void SetEdingPage() => CurrentPage = EditElementPage;
        public void SetAddElementPage() => CurrentPage = AddElementPage;
        public void SetDeleteAdvertismentPage()=> CurrentPage = DeleteAdvertisment;


    }
}
