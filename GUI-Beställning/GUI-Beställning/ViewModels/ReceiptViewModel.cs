using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GUI_Beställning.ViewModels
{
    public class ReceiptViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "ReceiptView";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<object> RecieptFoods => MainWindowViewModel.Order;
        public int OrderID => MainWindowViewModel.OrderID;
        public int SEKPrice => MainWindowViewModel.TotalPrice;

        public int EuroPrice { get; set; }

        #endregion
        public ReceiptViewModel(MainWindowViewModel viewModel = null,IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }
    }
}
