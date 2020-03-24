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

        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public RelayCommand AddSalladCommand { get; set; }

        public SalladMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var salladIE = repo.ShowSallads();
            Sallads = new ObservableCollection<Sallad>(salladIE.ToList());

            AddSalladCommand = new RelayCommand(AddSalladToOrder);
        }
        
        private void AddSalladToOrder(object id)
        {
            repo.AddSalladToOrder(MainWindowViewModel.OrderID, (int)id);
            MainWindowViewModel.ShowOrder();
        }
    }
}
