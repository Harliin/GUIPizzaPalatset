using GUI_Beställning.ViewModels;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for ExtraMenuView.xaml
    /// </summary>
    public partial class ExtraMenuView : UserControl
    {
        public ExtraMenuView()
        {
            InitializeComponent();
            this.DataContext = new ExtraMenuViewModel();
        }
    }
}
