using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using GUI_Beställning.ViewModels.Commands;
using System;
using System.ComponentModel;
using System.Windows.Threading;
using System.Threading.Tasks;
using DynamicData;

namespace GUI_Beställning.ViewModels
{
    public class PizzaMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PizzaMenu";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public OrderRepository repo = new OrderRepository();
        public static MainWindowViewModel MainWindowViewModel;

        public ObservableCollection<Pizza> Pizzas { get; set; }

        public Dispatcher Dispatcher => MainWindowViewModel.Dispatcher;
        #endregion

        #region Commands
        public RelayCommand AddPizzaCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public PizzaMenuViewModel(MainWindowViewModel viewModel = null ,IScreen screen = null)
        {
            AddPizzaCommand = new RelayCommand(AddPizzaToOrder);

            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            Pizzas = new ObservableCollection<Pizza>();
            ShowPizzas();

            if(MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

        public async Task ShowPizzas()
        {
            var pizzaIE = await repo.GetPizzas();
            this.Pizzas.Clear();
            this.Pizzas.AddRange(pizzaIE.ToList());
        }

        #region Command Methods
        /// <summary>
        /// Method to add a pizza to Order
        /// </summary>
        /// <param name="Pizza"></param>
        private async void AddPizzaToOrder(object Pizza)
        {
            Pizza pizza = (Pizza)Pizza;
            await repo.AddPizzaToOrder(MainWindowViewModel.OrderID, pizza.ID);

            await Task.Run(MainWindowViewModel.OrderChanged);
        }

        #endregion
    }


}
