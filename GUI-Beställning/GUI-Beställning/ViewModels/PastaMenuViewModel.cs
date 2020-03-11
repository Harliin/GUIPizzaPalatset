using GUI_Beställning.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    class PastaMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public OrderRepository repo = new OrderRepository();

        public ObservableCollection<Pasta> Pastas { get; set; }


        public PastaMenuViewModel()
        {
            Pastas = new ObservableCollection<Pasta>();
            GetPastas();
        }

        public void GetPastas()
        {
            for (int i = 0; i < 4; i++)
            {
                Pasta pasta = new Pasta();
                pasta.ID = i+1;
                pasta.Name = "Bolognese";
                pasta.Price = 90;
                Pastas.Add(pasta);
            }
        }
    }
}
