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
        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public RelayCommand AddExtraCommand { get; set; }
        public ExtraMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            var extrasIE = repo.ShowExtra();
            Extras = new ObservableCollection<Extra>(extrasIE.ToList());
            AddExtraCommand = new RelayCommand(AddExtraToOrder);
        }

        private void AddExtraToOrder(object Extra)
        {
            Extra extra = (Extra)Extra;
            repo.AddExtraToOrder(MainWindowViewModel.OrderID, extra.ID);
            MainWindowViewModel.Order = new ObservableCollection<object>();
        }
    }
}
