using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class PastaMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PastaMenu";

        public IScreen HostScreen { get; }

        #endregion

        public OrderRepository repo = new OrderRepository();

        public ObservableCollection<Pasta> Pastas { get; set; }


        public PastaMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
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
