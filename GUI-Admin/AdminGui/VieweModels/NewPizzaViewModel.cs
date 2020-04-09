using DB_Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Food;


namespace AdminGui
{
    public class NewPizzaViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public RelayComand CreatePizzaClick { get; set; }


     



        private string yourePrice { get; set; }
        public string YourePrice
        {
            get { return yourePrice; }
            set
            {
                yourePrice = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(YourePrice)));
            }
        }


        private string pizzaName { get; set; }
        public string PizzaName 
        {
         get { return pizzaName; }
            set
            {
                pizzaName = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PizzaName)));
            }
        }
       





        public static AdminRepository repo = new AdminRepository();

        public async Task CreateNewPizzaAsync()
        {
           int Price = Convert.ToInt32(YourePrice);
            await repo.AddPizzaAsync(PizzaName, Price);
        }
        public NewPizzaViewModel()
        {
            MainWindowViewModel.DataCotext.Title = "Ny Pizza";

            CreatePizzaClick = new RelayComand(CreatePizzaClickEvent);
    

        }

        public void CreatePizzaClickEvent(object parameter)
        {
            
            _ = CreateNewPizzaAsync();
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.PizzaMenu;
        }



    }
}
