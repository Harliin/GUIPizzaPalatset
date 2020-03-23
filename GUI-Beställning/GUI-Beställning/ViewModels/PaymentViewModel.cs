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
            var ordersIE = repo.ShowOrderByID(2);
            //var ordersIE = AllOrders();
            //Orders = new ObservableCollection<Order>(ordersIE);
        }

        


    }
}
