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

        public int OrderNumber
        {
            get { return orderNumber; }
            set { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
