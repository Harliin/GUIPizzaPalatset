using DB_OrderInfo.Food;
using GUI_OrderInfo.Views;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GUI_OrderInfo.ViewModels
{
    public class MainWindowViewModels
    {
        public List<Order> OngoingOrders { get; }
        public List<Order> CompleteOrder { get; }

        public MainWindowViewModels()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            OngoingOrders = repository.OngoingOrder().ToList();
            CompleteOrder = repository.CompleteOrder().ToList();

            //Printar ut pågående ordrar
            foreach (Order ongoingOrder in repository.OngoingOrder())
            {
                MainWindowView ongoing = new MainWindowView();
                ongoing.txbOngoing.Text = ongoingOrder.ToString();
            }

            // Printar ut färdiga ordrar 
            foreach (Order completeOrder in repository.CompleteOrder())
            {
                MainWindowView complete = new MainWindowView();
                complete.txbComplete.Text = completeOrder.ToString();
            }

            Thread.Sleep(3000); // uppdateras varje 3 sekunder
        }
    }
}
