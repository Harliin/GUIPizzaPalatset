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
    public class ExtraMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "ExtraMenu";

        public IScreen HostScreen { get; }

        #endregion

        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Extra> Extras { get; set; }

        public ExtraMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
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
