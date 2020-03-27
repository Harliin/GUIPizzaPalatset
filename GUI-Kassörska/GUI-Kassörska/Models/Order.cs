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
        public ObservableCollection<string> OrderList { get; set; }
        public List<string> Orders { get; set; }

        CashierRepository repo = new CashierRepository();

        public event PropertyChangedEventHandler PropertyChanged;

        public Order()
        {
            OrderList = new ObservableCollection<string>();
            
        }

        
    }
}