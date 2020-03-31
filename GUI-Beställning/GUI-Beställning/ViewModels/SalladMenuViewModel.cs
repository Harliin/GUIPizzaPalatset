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
        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<Sallad> Sallads { get; set; }

        public RelayCommand AddSalladCommand { get; set; }

        public SalladMenuViewModel(MainWindowViewModel viewModel = null, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            AddSalladCommand = new RelayCommand(AddSalladToOrder);
            var SalladIE = repo.ShowSallads();
            Sallads = new ObservableCollection<Sallad>(SalladIE.ToList());
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
