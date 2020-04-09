using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AdminGui
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        public RelayComand PizzaMenyClick { get; set; }
        public RelayComand ArbtareMenyClick { get; set; }
        public RelayComand IngridinetMenyClick { get; set; }
        public RelayComand OvrigtMenyClick { get; set; }


        public HomeViewModel()
        {
        
            PizzaMenyClick = new RelayComand(PizzaMenyClickEvent);
            ArbtareMenyClick = new RelayComand(ArbtareMenyClickEvent);
            IngridinetMenyClick = new RelayComand(IngridentMenyClickEvent);
            OvrigtMenyClick = new RelayComand(OvrigtMenyClickEvent);
            MainWindowViewModel.DataCotext.Title = "Hem";


        }
        public void PizzaMenyClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.PizzaMenu;
        }
        public void ArbtareMenyClickEvent(object parameter)
        {
            
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.Emplyees;
            
                
        }

        public void IngridentMenyClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.IngredentsMenu;
        }

        public void OvrigtMenyClickEvent(object parameter)
        {

            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.Ovrigt;
        }


    }


    
}
