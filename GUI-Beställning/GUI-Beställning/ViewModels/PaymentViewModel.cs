using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class PaymentViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PaymentMenu";

        public IScreen HostScreen { get; }
        #endregion

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Order> Orders { get; set; }
        private Order order { get; set; }
        public PaymentViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            var ordersIE = repo.ShowOrders();
            //var ordersIE = AllOrders();
            Orders = new ObservableCollection<Order>(ordersIE);
        }

        // Kanske kan använda oss av något som detta för att komma åt alla namn / priser per föremål
        public List<object> AllOrders()
        {
            List<object> menuItems = new List<object>();
            order.pizza.ForEach(pizza => { menuItems.Add(pizza.Name); });
            order.pasta.ForEach(pasta => { menuItems.Add(pasta.Name); });
            order.sallad.ForEach(sallad => { menuItems.Add(sallad.Name); });
            order.drink.ForEach(drink => { menuItems.Add(drink.Name); });
            order.extra.ForEach(extra => { menuItems.Add(extra.Name); });

            return menuItems;
            
        }
    }
}
