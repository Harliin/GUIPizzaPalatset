using DB_OrderInfo.Food;
using System.Threading;

namespace GUI_OrderInfo.ViewModels
{
    class MainWindowViewModels
    {
        public MainWindowViewModels()
        {
            OrderInfoRepository repository = new OrderInfoRepository();

            // Printar ut pågående och färdiga ordrar
            foreach (Order ongoingOrder in repository.OngoingOrder())
            {

            }

            // Printar ut färdiga ordrar 
            foreach (Order completeOrder in repository.CompleteOrder())
            {

            }
            Thread.Sleep(3000);
        }
    }
}
