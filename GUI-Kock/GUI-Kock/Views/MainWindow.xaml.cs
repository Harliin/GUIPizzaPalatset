using GUI_Kock.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reactive.Disposables;



namespace GUI_Kock.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {

        public MainWindow()
        {
            InitializeComponent();

            this.ViewModel = new MainWindowViewModel(this);
            this.WhenActivated(disposables =>
            {
              
                this.BindCommand(ViewModel, x => x.GoToOrderView, x => x.loginBtm)
               .DisposeWith(disposables);
            });
        }
    }
}
