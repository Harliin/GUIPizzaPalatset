
using DB_Kock;
using DynamicData;
using Food;
using GUI_Kock.ViewModels.Commands;
using GUI_Kock.Views;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_Kock.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {

        public static ChefRepository repo = new ChefRepository();

        public ObservableCollection<Employee> Employees { get; private set; }

        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; private set; }

        public ReactiveCommand<Unit, IRoutableViewModel> LoginCommand { get; private set; }

        private readonly Employee _login;

        private string _password;

        private string _userName;

        #region Routing
        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
        #endregion


        public LoginViewModel(RoutingState state, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));
            Employees = new ObservableCollection<Employee>();
            Router = state;
            _login = new Employee();
            //LoginCommand = new RelayCommand(Login);

            //Parameter for LoginCommand.
            var canLogin = this.WhenAnyValue
            (x => x.Name, x => x.Password,
            (n, p) =>
            !string.IsNullOrWhiteSpace(n) &&
            !string.IsNullOrWhiteSpace(p) &&
            (n == "Tony" && p == "admin123") ||
            (n == "Giovanni" && p == "bagare2") ||
            (n == "ba1" && p == "ba1") ||
            (n == "VD" && p == "123"));

            LoginCommand = ReactiveCommand.CreateFromObservable(() => (Router.Navigate.Execute(new OrderViewModel(Router))), canLogin);
            this.WhenAnyValue(x => x.Name).Subscribe(n => _login.Name = n);
            this.WhenAnyValue(x => x.Password).Subscribe(p => _login.Password = p);
        }

        public string Name
        {
            get { return _userName; }
            set { this.RaiseAndSetIfChanged(ref _userName, value); }
        }


        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }

        /// <summary>
        /// Gets the Employy instance
        /// </summary>

        public Employee LoginAdmin
        {
            get
            {
                return _login;
            }
        }

        // <summary>
        // Gets the loginCommand for the ViewModel  
        // </summary>
        //public RelayCommand LoginCommand
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Checks that there's a user in database. Användarnamn: ba1  Lösen: ba1 
        /// </summary>
        /// <returns></returns>
        //public bool CheckUser()
        //{
        //    string AdminName = _userName;
        //    string password = _password;

        //    var admins = repo.GetChefs(AdminName, password);

        //    if
        //    ((AdminName == "Tony" &&)(password == "admin123") ||
        //    (AdminName == "Giovanni") && (password == "bagare2") ||
        //    (AdminName == "ba1") && (password == "ba1") ||
        //    (AdminName == "VD") && (password == "123")) ;
        //    {
        //        return true;
        //    }
        //    else
        //    {

        //        Console.WriteLine("Felaktigt inloggning!");
        //        Console.ReadKey();
        //        Login();
        //    }
        //    return true;
        //}

        /// <summary>
        /// Action till LoginCommand
        /// </summary>
        /// <returns></returns>
        //public void Login()
        //{
        //    MessageBox.Show("Inloggning lyckades!");
        //    Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));
        //    GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel(Router)));
            
        //}

        public void Populate()
        {
            IEnumerable<Employee> employee = repo.GetChefsList();
            Employees.AddRange(employee);
        }

    }
}


