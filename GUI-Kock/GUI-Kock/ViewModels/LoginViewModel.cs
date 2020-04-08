
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
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GUI_Kock.ViewModels
{
    public class LoginViewModel : ReactiveObject, IRoutableViewModel
    {
        #region Properties
        public static ChefRepository repo = new ChefRepository();

        public static ObservableCollection<Employee> Employees { get; private set; }

        public List<string> EmployeeNames { get; private set; }        

        private string _password;
        public string Name { get; set; }

        public string Password
        {
            get { return _password; }
            set { this.RaiseAndSetIfChanged(ref _password, value); }
        }
        #endregion

        #region Commands
        public ReactiveCommand<Unit, IRoutableViewModel> GoToOrderView { get; private set; }
        // <summary>
        // Gets the loginCommand for the ViewModel  
        // </summary>
        public RelayCommand LoginCommand { get; set; }
        #endregion

        #region Routing
        public string UrlPathSegment => "Login";
        public IScreen HostScreen { get; private set; }
        public static RoutingState Router { get; private set; }
        #endregion

        #region Default Constructor

        public LoginViewModel(RoutingState state = null, IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            Locator.CurrentMutable.Register(() => new OrderView(), typeof(IViewFor<OrderViewModel>));
            Employees = new ObservableCollection<Employee>();
            if (Router == null)
            {
                Router = state;
            }
            
            EmployeeNames = new List<string>();
            LoginCommand = new RelayCommand(Login);
        }

        #endregion

        /// <summary>
        /// Checks if the Password and user is correct
        /// </summary>
        /// <returns></returns>
        public bool CheckUser()
        {
            //Creates a dictionary of the employyes with the Name as key and password as the value
            var tempList = Employees.ToList();
            Dictionary<string, string> employeeNames = new Dictionary<string, string>();
            tempList.ForEach(x => employeeNames.Add(x.Name, x.Password));

            if (employeeNames.ContainsKey(Name))
            {
                employeeNames.TryGetValue(Name, out string correctKey);
                if (Password == correctKey)
                {
                    Name = Name;
                    return true;
                }
                else
                {
                    MessageBox.Show("Fel Lösenord!");
                    return false;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Action till LoginCommand
        /// </summary>
        /// <returns></returns>
        public void Login(object paramater)
        {
            if (Name != null && Password != null)
            {
                if (CheckUser())
                {
                    Router.Navigate.Execute(new OrderViewModel(Name));
                }
            }
        }

        /// <summary>
        /// Populates the Employee list and employeenames list
        /// </summary>
        public void Populate()
        {
            IEnumerable<Employee> employee = repo.GetChefsList();
            Employees.AddRange(employee);
            var templist = employee.ToList();
            templist.ForEach(x => EmployeeNames.Add(x.Name));
        }

    }
}


