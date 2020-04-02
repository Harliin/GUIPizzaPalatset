using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using GUI_Beställning.ViewModels.Commands;
using System;
using System.ComponentModel;

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

        private ObservableCollection<Pizza> pizzas;
        public ObservableCollection<Pizza> Pizzas
        {
            get { return pizzas; }
            set
            {
                var pizzaIE = repo.GetPizzas();
                pizzas = new ObservableCollection<Pizza>(pizzaIE.ToList());
            }
        }
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

            if(MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

        #region Command Methods
        /// <summary>
        /// Method to add a pizza to Order
        /// </summary>
        /// <param name="Pizza"></param>
        private void AddPizzaToOrder(object Pizza)
        {
            Pizza pizza = (Pizza)Pizza;
            repo.AddPizzaToOrder(MainWindowViewModel.OrderID, pizza.ID);

            MainWindowViewModel.OrderChanged();
        }

        #endregion
    }


}
