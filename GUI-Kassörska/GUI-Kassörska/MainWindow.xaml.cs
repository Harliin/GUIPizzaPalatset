using GUI_Kassörska.ViewModels;
using System.Windows;

namespace GUI_Kassörska
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel Main = new MainViewModel() 
        {
            OrderString = "hej"
        };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = Main;
        }
    }
}
