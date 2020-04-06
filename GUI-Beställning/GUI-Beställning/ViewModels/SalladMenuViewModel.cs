using DynamicData;
using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;

namespace GUI_Beställning.ViewModels
{
    public class SalladMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "SalladMenu";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public OrderRepository repo = new OrderRepository();
        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<Sallad> Sallads { get; set; }
        public Dispatcher Dispatcher = MainWindowViewModel.Dispatcher;
        #endregion

        #region Commands
        public RelayCommand AddSalladCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public SalladMenuViewModel(MainWindowViewModel viewModel = null, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
           
            AddSalladCommand = new RelayCommand(AddSalladToOrder);
            ShowSallad();
            if(MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }
        
        /// <summary>
        /// Command Method to add Sallad to Order
        /// </summary>
        /// <param name="Sallad"></param>
        /// 

        public async void ShowSallad()
        {
            Sallads = new ObservableCollection<Sallad>();
            var SalladIE = await repo.ShowSallads();
            await Dispatcher.InvokeAsync(Sallads.Clear);
            await Dispatcher.InvokeAsync(() => { Sallads.AddRange(SalladIE.ToList()); });

        }
        private async void AddSalladToOrder(object Sallad)
        {
            Sallad sallad = (Sallad)Sallad;
            await repo.AddSalladToOrder(MainWindowViewModel.OrderID, sallad.ID);
            await MainWindowViewModel.OrderChanged();
        }
    }
}
