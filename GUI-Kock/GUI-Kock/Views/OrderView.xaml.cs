using GUI_Kock.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Kock.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : ReactiveUserControl<OrderViewModel>
    {
        public OrderView()
        {

            InitializeComponent();

            this.DataContext = new OrderViewModel();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.OngoinOrders, view => view.ongoingorder.ItemsSource)
                .DisposeWith(disposables);
                ViewModel.PopulateOrders();


                this.BindCommand(ViewModel, x => x.GoToLoginView, x => x.exit);

               // this.Bind(ViewModel, vm => vm.Name, v => v.user.Text)
               //.DisposeWith(disposables);

            });
        }
    }
}
