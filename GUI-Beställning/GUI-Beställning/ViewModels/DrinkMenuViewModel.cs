using GUI_Beställning.Models.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GUI_Beställning.ViewModels
{
    class DrinkMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public OrderRepository repo = new OrderRepository();

        public ObservableCollection<Drink> Drinks { get; set; }

        public DrinkMenuViewModel()
        {
            Drinks = new ObservableCollection<Drink>();
            GetDrinks();
        }

        private void GetDrinks()
        {
            for (int i = 0; i < 4; i++)
            {
                Drink drink = new Drink();
                drink.ID = i + 1;
                drink.Name = "Trocadero";
                drink.Price = 15;
                Drinks.Add(drink);
            }
        }
    }
}
