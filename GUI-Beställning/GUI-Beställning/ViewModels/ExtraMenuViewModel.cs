using DynamicData;
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
using System.Threading.Tasks;
using System.Windows.Threading;

namespace GUI_Beställning.ViewModels
{
    public class ExtraMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "ExtraMenu";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public OrderRepository repo = new OrderRepository();
        public ObservableCollection<Extra> Extras { get; set; }
        public static MainWindowViewModel MainWindowViewModel;

        public Dispatcher Dispatcher = MainWindowViewModel.Dispatcher;
        #endregion

        #region Commands
        public RelayCommand AddExtraCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public ExtraMenuViewModel(MainWindowViewModel viewModel =null,IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            
            Extras = new ObservableCollection<Extra>();
            AddExtraCommand = new RelayCommand(AddExtraToOrder);
            ShowExtras();

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }
        public async void ShowExtras()
        {
            var extrasIE = await repo.ShowExtra();
            await Dispatcher.InvokeAsync(Extras.Clear);
            await Dispatcher.InvokeAsync(() => Extras.AddRange(extrasIE.ToList()));
        }

        /// <summary>
        /// Command Method to add Extra to order
        /// </summary>
        /// <param name="Extra"></param>
        private async void AddExtraToOrder(object Extra)
        {
            Extra extra = (Extra)Extra;
            await repo.AddExtraToOrder(MainWindowViewModel.OrderID, extra.ID);
            await MainWindowViewModel.OrderChanged();
        }
    }
}
