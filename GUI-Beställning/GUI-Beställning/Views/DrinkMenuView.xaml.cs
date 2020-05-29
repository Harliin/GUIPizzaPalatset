using GUI_Beställning.ViewModels;
using ReactiveUI;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for DrinkMenuView.xaml
    /// </summary>
    public partial class DrinkMenuView : ReactiveUserControl<DrinkMenuViewModel>
    {
        public DrinkMenuView()
        {
            InitializeComponent();
            this.DataContext = new DrinkMenuViewModel();
        }
    }
}
