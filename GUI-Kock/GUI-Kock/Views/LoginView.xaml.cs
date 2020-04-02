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
            this.DataContext = new LoginViewModel();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.EmployeeNames, view => view.userName.ItemsSource)
                .DisposeWith(disposables);
                ViewModel.Populate();

                this.Bind(ViewModel, vm => vm.Name, v => v.userName.Text)
                .DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.Password, v => v.password.Text)
                .DisposeWith(disposables);

                this.BindCommand(ViewModel, x => x.LoginCommand, x => x.loginBtm)
                .DisposeWith(disposables);

            });
        }
    }
}
