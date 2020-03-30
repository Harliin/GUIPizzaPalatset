using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace GUI_Beställning.ViewModels
{
    public class DrinkMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "DrinkMenu";

        public IScreen HostScreen { get; }

        #endregion
        
        public OrderRepository repo = new OrderRepository();

        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public ObservableCollection<Drink> Drinks { get; set; }
        public RelayCommand AddDrinkCommand { get; set; }
        public DrinkMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var drinksIE = repo.ShowDrinks();
            Drinks = new ObservableCollection<Drink>(drinksIE.ToList());
            AddDrinkCommand = new RelayCommand(AddDrinkToOrder);
        }

        private void AddDrinkToOrder(object Drink)
        {
            Drink drink = (Drink)Drink;
            repo.AddDrinkToOrder(MainWindowViewModel.OrderID, drink.ID);
            MainWindowViewModel.ShowOrder();
        }
    }
}
