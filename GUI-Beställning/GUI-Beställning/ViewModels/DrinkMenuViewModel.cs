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

        #region Properties
        public OrderRepository repo = new OrderRepository();

        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<Drink> Drinks { get; set; }
        #endregion

        #region Commands
        public RelayCommand AddDrinkCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public DrinkMenuViewModel(MainWindowViewModel viewModel = null, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            var drinksIE = repo.ShowDrinks();
            Drinks = new ObservableCollection<Drink>(drinksIE.ToList());
            AddDrinkCommand = new RelayCommand(AddDrinkToOrder);

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

        /// <summary>
        /// Command Method to add Drink to order
        /// </summary>
        /// <param name="Drink"></param>
        private void AddDrinkToOrder(object Drink)
        {
            Drink drink = (Drink)Drink;
            repo.AddDrinkToOrder(MainWindowViewModel.OrderID, drink.ID);
            MainWindowViewModel.OrderChanged();
        }
    }
}
