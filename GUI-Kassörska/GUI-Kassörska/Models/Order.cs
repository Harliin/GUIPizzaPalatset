using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace GUI_Kassörska.ViewModels
{
    public class Order : INotifyPropertyChanged
    {
        public int OrderID { get; set; }
        public eStatus Status { get; set; }
        public int EmployeeID { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4 }

        private ObservableCollection<Order> ongoingOrders = new ObservableCollection<Order>();

        

        //Observable collection of orders
        public ObservableCollection<Order> OngoingOrders { get { return ongoingOrders; } set { } } // HÄR SKA DET TILL NÅT MAGISKT!


        //private List<string> ordersTest = new List<string>
        //{
        //    "Capricciosa",
        //    "Vesuvio",
        //    "Hawaii"
        //};

        //public List<string> OrdersTest { get { return ordersTest; } set { ordersTest = value; } }

        //Create an instance of Cashier repository
        CashierRepository repo = new CashierRepository();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public Order()
        {
            var Order = new ObservableCollection<Order>();
            
        }

        //public void Populate()
        //{
        //    IEnumerable<Order> orders = repo.ShowAllOrders();
        //    Orders.AddRange(Orders);
        //}
    }
}