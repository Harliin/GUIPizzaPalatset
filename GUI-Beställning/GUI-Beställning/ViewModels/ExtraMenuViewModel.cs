using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
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
    public class ExtraMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "ExtraMenu";

        public IScreen HostScreen { get; }

        #endregion

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Extra> Extras { get; set; }
        public RelayCommand AddExtraCommand { get; set; }
        public ExtraMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var extrasIE = repo.ShowExtra();
            Extras = new ObservableCollection<Extra>(extrasIE.ToList());
            AddExtraCommand = new RelayCommand(AddExtraToOrder);
        }

        private void AddExtraToOrder(object id)
        {
            repo.AddExtraToOrder(2, (int)id);
        }
    }
}
