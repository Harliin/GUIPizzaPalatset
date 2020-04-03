using DB_OrderInfo.Food;
using DynamicData;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Windows;

namespace GUI_OrderInfo.ViewModels
{
    public class MainWindowViewModels : ReactiveObject //, IScreen
    {
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

        }

        #endregion

        #region Populate metod

        public void Populate()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            OngoingOrders.AddRange(repository.OngoingOrder());
            CompleteOrder.AddRange(repository.OngoingOrder());
        }

        #endregion
    }
}
