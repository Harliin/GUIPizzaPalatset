using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    class SalladMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Sallad> Sallads { get; set; }

        public SalladMenuViewModel()
        {
            Sallads = new ObservableCollection<Sallad>();
            GetSallads();
        }
        public void GetSallads()
        {
            for (int i = 0; i < 4; i++)
            {
                Sallad sallad = new Sallad();
                sallad.ID = i + 1;
                sallad.Name = "Aglio Olio";
                sallad.Price = 85;

                Sallads.Add(sallad);

            }
        }
    }
}
