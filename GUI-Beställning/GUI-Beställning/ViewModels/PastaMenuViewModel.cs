using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
            var PastaIE = repo.ShowPastas();
            Pastas = new ObservableCollection<Pasta>(PastaIE.ToList());
            
        }

    }
}
