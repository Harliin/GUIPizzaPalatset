using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    class ExtraMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Extra> Extras { get; set; }

        public ExtraMenuViewModel()
        {
            Extras = new ObservableCollection<Extra>();
            GetExtras();
        }

        private void GetExtras()
        {
            for (int i = 0; i < 4; i++)
            {
                Extra extra = new Extra
                {
                    OrderID = i + 1,
                    Name = "Vitlöksbröd",
                    Price = 20
                };
                Extras.Add(extra);
            }
        }
    }
}
