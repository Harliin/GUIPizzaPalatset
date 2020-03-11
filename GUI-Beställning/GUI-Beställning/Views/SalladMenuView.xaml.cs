using GUI_Beställning.ViewModels;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for SalladMenuView.xaml
    /// </summary>
    public partial class SalladMenuView : UserControl
    {
        public SalladMenuView()
        {
            InitializeComponent();
            this.DataContext = new SalladMenuViewModel();
        }
    }
}
