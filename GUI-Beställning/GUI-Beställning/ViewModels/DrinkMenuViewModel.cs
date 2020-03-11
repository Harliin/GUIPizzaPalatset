using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace GUI_Beställning.ViewModels
{
    public class DrinkMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "DrinkMenu";

        public IScreen HostScreen { get; }

        #endregion
        
        public OrderRepository repo = new OrderRepository();

        public ObservableCollection<Drink> Drinks { get; set; }

        public DrinkMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Drinks = new ObservableCollection<Drink>();
            GetDrinks();
        }

        public void GetDrinks()
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
