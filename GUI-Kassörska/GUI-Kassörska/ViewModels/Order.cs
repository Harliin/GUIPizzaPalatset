using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.ViewModels
{
    public class Order : INotifyPropertyChanged
    {
        private int orderNumber;

        public Order()
        {

        }

        public eStatus Status { get; set; }
        public enum eStatus { Pågående = 1, Tillagning = 2, Klar = 3, Avhämtat = 4 }

        public int OrderNumber
        {
            get { return orderNumber; }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
