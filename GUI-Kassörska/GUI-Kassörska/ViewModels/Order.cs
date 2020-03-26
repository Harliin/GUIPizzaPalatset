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
        public Order()
        {
            OrderList = new ObservableCollection<string>()
            {
                "Pågående order 1",
                "Pågående order 2",
                "Pågående order 3"
            };
        }
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public int EmployeeID { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4 }  
    }
}
