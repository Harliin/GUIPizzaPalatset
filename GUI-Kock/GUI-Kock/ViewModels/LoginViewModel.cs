
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
            LoginCommand = new UserLoginCommand(this);
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
        public ICommand LoginCommand
        {
            get;
            private set;
        }


        public bool CheckUser()
        {
            string AdminName = admin.name;
            string password = admin.password;

            var admins = repo.GetChefs(AdminName, password);

            if (admins.Count() == 0)
            {
                MessageBox.Show("Felaktigt inloggning!");
                CheckUser();
            }
            else
            {
                return true;
            }
            return true;
        }

        public void Login()
        {
            //Registrerar din nästa view. denna behövs för att kunna koppla den mot ett command
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));

            GoToOrderView = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new OrderViewModel(Router)));
        }

        public async Task Populate()
        {
            IEnumerable<Employee> employee = await repo.GetChefsList();
            Employees.AddRange(employee);
        }


    }

}

