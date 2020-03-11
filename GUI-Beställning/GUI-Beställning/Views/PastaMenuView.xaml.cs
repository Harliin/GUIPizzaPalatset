using GUI_Beställning.ViewModels;
using System.Windows.Controls;

namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for PastaMenuView.xaml
    /// </summary>
    public partial class PastaMenuView : UserControl
    {
        public PastaMenuView()
        {
            InitializeComponent();
            this.DataContext = new PastaMenuViewModel();
        }
    }
}
