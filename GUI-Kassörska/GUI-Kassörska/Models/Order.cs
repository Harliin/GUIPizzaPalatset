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

        private ObservableCollection<Order> orders { get; set; }
        //Observable collection of orders
        public ObservableCollection<Order> Orders { get { return orders; } private set { } }

        //Create an instance of Cashier repository
        CashierRepository repo = new CashierRepository();

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public Order()
        {
            var Order = new ObservableCollection<Order>();
            
        }

        public void Populate()
        {
            IEnumerable<Order> orders = repo.ShowAllOrders();
            Orders.AddRange(orders);
        }
    }
}