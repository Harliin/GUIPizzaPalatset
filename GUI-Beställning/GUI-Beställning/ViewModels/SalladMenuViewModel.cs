using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;


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

        public static MainWindowViewModel MainWindowViewModel;
        public RelayCommand AddSalladCommand { get; set; }

        public SalladMenuViewModel(MainWindowViewModel viewModel = null, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            AddSalladCommand = new RelayCommand(AddSalladToOrder);

            Sallads = new ObservableCollection<Sallad>();
            if(MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }
        
        private void AddSalladToOrder(object Sallad)
        {
            Sallad sallad = (Sallad)Sallad;
            repo.AddSalladToOrder(MainWindowViewModel.OrderID, sallad.ID);
            MainWindowViewModel.OrderChanged();
        }
    }
}
