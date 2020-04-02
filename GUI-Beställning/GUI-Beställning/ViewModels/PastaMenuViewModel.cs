using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;


namespace GUI_Beställning.ViewModels
{
    public class PastaMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PastaMenu";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public OrderRepository repo = new OrderRepository();

        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<Pasta> Pastas { get; set; }

        #endregion

        #region Commands
        public RelayCommand AddPastaCommand { get; set; }
        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="screen"></param>
        public PastaMenuViewModel(MainWindowViewModel viewModel = null ,IScreen screen = null)
        {
            AddPastaCommand = new RelayCommand(AddPastaToOrder);
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            var PastaIE = repo.ShowPastas();
            Pastas = new ObservableCollection<Pasta>(PastaIE.ToList());

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
        }

        /// <summary>
        /// CommandMethod to add Pasta to order
        /// </summary>
        /// <param name="Pasta"></param>
        private void AddPastaToOrder(object Pasta)
        {
            Pasta pasta = (Pasta)Pasta;
            repo.AddPastaToOrder(MainWindowViewModel.OrderID, pasta.ID);
            MainWindowViewModel.OrderChanged();
        }
    }
}
