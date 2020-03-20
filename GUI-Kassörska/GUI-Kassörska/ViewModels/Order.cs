using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.ViewModels
{
    public class Order : ObservableObject
    {
        public int ID { get; set; }
        public eStatus Status { get; set; }
        public int EmployeeID { get; set; }
        public enum eStatus { UnderBeställning = 1, Tillagning = 2, Klar = 3, Avhämtad = 4 }
        public List<Order> Orders { get; set; }
    }
}
