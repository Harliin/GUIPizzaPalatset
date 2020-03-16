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
    public class SalladMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "SalladMenu";

        public IScreen HostScreen { get; }

        #endregion

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Sallad> Sallads { get; set; }


        public SalladMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var salladIE = repo.ShowSallads();
            Sallads = new ObservableCollection<Sallad>(salladIE.ToList());
            
        }
        
    }
}
