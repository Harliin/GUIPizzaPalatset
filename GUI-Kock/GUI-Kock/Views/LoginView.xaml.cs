using GUI_Kock.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI_Kock.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : ReactiveUserControl<LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
            
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Employees, view => view.userName.ItemsSource)
                .DisposeWith(disposables);
                ViewModel.Populate();

<<<<<<< HEAD
=======
                //this.BindCommand(ViewModel, x => x.LoginCommand, x => x.loginBtm)
                //.DisposeWith(disposables);

>>>>>>> 106ea308d0c15c153de804aa3053ad5557ccd71b
            });
        }
    }
}
