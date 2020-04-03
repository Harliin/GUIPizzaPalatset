using GUI_OrderInfo.ViewModels;
using ReactiveUI;
using System.Reactive.Disposables;

namespace GUI_OrderInfo.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : ReactiveWindow<MainWindowViewModels>
    {
        public MainWindowView()
        {
            this.ViewModel = new MainWindowViewModels(this);

            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, oo => oo.OngoingOrders, o => o.txbOngoing.ItemsSource)
                .DisposeWith(disposables);

                this.OneWayBind(ViewModel, co => co.CompleteOrder, c => c.txbComplete.ItemsSource)
                .DisposeWith(disposables);

                ViewModel.Populate();
            });
        }
    }
}
