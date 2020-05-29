using GUI_Beställning.ViewModels;
using ReactiveUI;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for SalladMenuView.xaml
    /// </summary>
    public partial class SalladMenuView : ReactiveUserControl<SalladMenuViewModel>
    {
        public SalladMenuView()
        {
            InitializeComponent();
            this.DataContext = new SalladMenuViewModel();
        }
    }
}
