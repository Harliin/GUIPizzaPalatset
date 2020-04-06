using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI_Beställning.ViewModels
{
    public class PaymentViewModel : ReactiveObject, IRoutableViewModel
    {

        #region For Reactive UI
        public string UrlPathSegment => "PaymentMenu";

        public IScreen HostScreen { get; }
        #endregion
        #region Properties
        public OrderRepository repo = new OrderRepository();
        public static MainWindowViewModel MainWindowViewModel;
        public Order CurrentOrder { get; set; }
        public ObservableCollection<object> Foods => MainWindowViewModel.Order;
        public int OrderID => MainWindowViewModel.OrderID;

        #endregion

        #region Commands
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand PaymentCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public PaymentViewModel(MainWindowViewModel viewModel = null,IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }

            //Commands

            RemoveCommand = new RelayCommand(RemoveFoodFromOrder);
            PaymentCommand = new RelayCommand(MainWindowViewModel.PaymentCommandMethod);
        }

    
        /// <summary>
        /// Method To remove Food From a Order
        /// </summary>
        /// <param name="parameter"></param>
        public async void RemoveFoodFromOrder(object parameter)
        {
            //await Task.Run(() =>
            //{
                var Type = parameter.GetType();

                if (Type == typeof(Pizza))
                {
                    Pizza pizza = (Pizza)parameter;
                    await repo.RemovePizzaFromOrder(OrderID, pizza.ID);
                }
                else if (Type == typeof(Pasta))
                {
                    Pasta pasta = (Pasta)parameter;
                    await repo.RemovePastaFromOrder(OrderID, pasta.ID);
                }
                else if (Type == typeof(Sallad))
                {
                    Sallad sallad = (Sallad)parameter;
                    await repo.RemoveSalladFromOrder(OrderID, sallad.ID);
                }
                else if (Type == typeof(Drink))
                {
                    Drink drink = (Drink)parameter;
                    await repo.RemoveDrinkFromOrder(OrderID, drink.ID);
                }
                else if (Type == typeof(Extra))
                {
                    Extra extra = (Extra)parameter;
                    await repo.RemoveExtraFromOrder(OrderID, extra.ID);
                }
                MainWindowViewModel.OrderChanged();
            //});
            
        }

    }

}
