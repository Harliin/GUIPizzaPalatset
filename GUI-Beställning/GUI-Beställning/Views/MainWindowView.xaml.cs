
using GUI_Beställning.ViewModels;
using System.Windows;


namespace GUI_Beställning.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
        }
    }
}
