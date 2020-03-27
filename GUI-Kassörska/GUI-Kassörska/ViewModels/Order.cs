using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.ViewModels
{
    public class Order
    {
        public ObservableCollection<string> OrderList { get; set; }

        CashierRepository repo = new CashierRepository();
        public Order()
        {
            OrderList = new ObservableCollection<string>();
            
        }
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public int EmployeeID { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4 }  
    }
}