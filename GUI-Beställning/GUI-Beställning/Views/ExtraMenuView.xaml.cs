using GUI_Beställning.ViewModels;
using ReactiveUI;
using System.Windows.Controls;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for ExtraMenuView.xaml
    /// </summary>
    public partial class ExtraMenuView : ReactiveUserControl<ExtraMenuViewModel>
    {
        public ExtraMenuView()
        {
            InitializeComponent();
            this.DataContext = new ExtraMenuViewModel();
        }
    }
}
