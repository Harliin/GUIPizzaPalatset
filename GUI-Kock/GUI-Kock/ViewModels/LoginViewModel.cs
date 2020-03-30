
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
        private Employee admin;
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; private set; }
        public ReactiveCommand<Unit, Unit> LoginCommand { get; private set; }

        #region Routing
        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; private set; }
        public RoutingState Router { get; private set; }
        #endregion


        public LoginViewModel(RoutingState state, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Employees = new ObservableCollection<Employee>();
            admin = new Employee();
            Router = state;
            LoginCommand = ReactiveCommand.Create(Login, canLogin);
            //Använd detta eller logik ovanpå. Plus lägg till (CheckUser) när Binding knappen fungerar. 
            // LoginCommand = new RelayCommand(Login); 
        }

        /// <summary>
        /// Gets the Employy instance
        /// </summary>

        public Employee Admin
        {
            get
            {
                return admin;
            }
        }

        /// <summary>
        /// Gets the loginCommand for the ViewModel  
        /// </summary>
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
        //    string AdminName = admin.name;
        //    string password = admin.password;

        //    var admins = repo.GetChefs(AdminName, password);

        //    if (admins == admin)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Felaktigt inloggning!");
        //        CheckUser();
        //    }
        //    return true;
        //}


        //Parameter for LoginCommand, preventing the user from proceeding until the validation conditions are met.
        //var canLogin => this.WhenAnyValue(
        //   ( x => x.admin.name, x => x.admin.password,
        //    (user, pass) =>
        //        !string.IsNullOrWhiteSpace(user) &&
        //        !string.IsNullOrWhiteSpace(pass) &&
        //        user == "Tony" && pass == "admin123" || 
        //        user == "Giovanni" && pass == "bagare2" || 
        //        user == "ba1" && pass == "ba1" ||
        //        user == "VD" && pass == "123"))

        //   .DistinctUntilChanged();


        //Action till LoginCommand
        public void Login()
        {
            //Registrerar nästa view. Denna behövs för att kunna koppla den mot ett command
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));
            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel(Router)));
        }

        public void Populate()
        {
            IEnumerable<Employee> employee = repo.GetChefsList();
            Employees.AddRange(employee);
        }


    }

}

