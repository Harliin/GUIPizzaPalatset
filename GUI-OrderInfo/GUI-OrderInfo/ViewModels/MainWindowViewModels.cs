// ===============================
// AUTHOR           : Elchin Jabbari
// CREATE DATE      : 2020-04-07
// COURSE           : Object Orientering Programmering 2
// GROUP            : 1
// ===============================
// PROJECT          : Pizzeria Palatset
// PROGRAM          : Order information screen 
// VERSION          : 1.1 
//==================================

using DB_OrderInfo.Food;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace GUI_OrderInfo.ViewModels
{
    public class MainWindowViewModels : ReactiveObject
    {
        // Skapas timer för skärm uppdatering
        DispatcherTimer _clock;

        #region ObservableCollections metoder
        public ObservableCollection<Order> OngoingOrders { get; }

        public ObservableCollection<Order> CompleteOrder { get; }

        #endregion

        #region routing

        public RoutingState Router { get; }
        public Window ThisWindow { get; set; }

        #endregion

        #region Constructor

        public MainWindowViewModels(Window thisWindow)
        {
            // Initialize the Router.
            Router = new RoutingState();

            this.ThisWindow = thisWindow;

            OrderInfoRepository repository = new OrderInfoRepository();

            OngoingOrders = new ObservableCollection<Order>();
            CompleteOrder = new ObservableCollection<Order>();

            // Sätter timer för skärm uppdatering om visst interval
            _clock = new DispatcherTimer();
            _clock.Interval = new TimeSpan(0, 0, 5);
            _clock.Tick += (object sender, EventArgs e) =>
            {
                Populate();
            };
            _clock.Start();
        }

        #endregion

        #region Populate metod

        public void Populate()
        {
            OrderInfoRepository repo = new OrderInfoRepository();

            OngoingOrders.Clear();
            CompleteOrder.Clear();

            OngoingOrders.AddRange(repo.OngoingOrder());
            CompleteOrder.AddRange(repo.CompleteOrder());
        }

        #endregion
    }
}
