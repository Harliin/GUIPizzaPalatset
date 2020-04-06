using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
            
            Drinks = new ObservableCollection<Drink>();
            Task.Run(ShowDrinks);
            AddDrinkCommand = new RelayCommand(AddDrinkToOrder);

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

        public async void ShowDrinks()
        {
            var drinksIE = await repo.ShowDrinks();
            Drinks.Clear();
            Drinks.AddRange(drinksIE.ToList());
        }
        /// <summary>
        /// Command Method to add Drink to order
        /// </summary>
        /// <param name="Drink"></param>
        private async void AddDrinkToOrder(object Drink)
        {
            Drink drink = (Drink)Drink;
            await repo.AddDrinkToOrder(MainWindowViewModel.OrderID, drink.ID);
            MainWindowViewModel.OrderChanged();
        }
    }
}
