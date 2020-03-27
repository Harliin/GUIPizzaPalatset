using GUI_OrderInfo.ViewModels;
using System.Windows;

namespace GUI_OrderInfo.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModels();
        }
    }
}
