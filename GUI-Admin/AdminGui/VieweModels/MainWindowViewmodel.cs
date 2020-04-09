using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AdminGui
{

   public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string title;

        public string Title { get { return title; } set { title = value; PropertyChanged(this, new PropertyChangedEventArgs(nameof(Title))); } }
        public RelayComand HomeClick { get; set; }

        public static MainWindowViewModel DataCotext { get; set; }
        private MenyePages currentPage;
        public MenyePages CurrentPage {
            
            get { return currentPage; } 
            set { currentPage = value; PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentPage))); } 
           
        } 
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        public MainWindowViewModel()
        {
            DataCotext = this;
            HomeClick = new RelayComand(HemMenyClickEvent);
            CurrentPage = MenyePages.Home;
            Title = "Hem";

        }
        public void HemMenyClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.Home;
        }
    }
}
