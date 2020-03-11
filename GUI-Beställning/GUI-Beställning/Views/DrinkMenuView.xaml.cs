using GUI_Beställning.ViewModels;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for DrinkMenuView.xaml
    /// </summary>
    public partial class DrinkMenuView : UserControl
    {
        public DrinkMenuView()
        {
            InitializeComponent();
            this.DataContext = new DrinkMenuViewModel();
        }
    }
}
