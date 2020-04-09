using DB_Admin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Input;
using Food;

namespace AdminGui
{
    class EmployesViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        private ObservableCollection<MyEmplyeesViewModel> employeesListItems;
        public ObservableCollection<MyEmplyeesViewModel> EmployeesListItem
        {
            get { return employeesListItems; }
            set
            {
                employeesListItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(EmployeesListItem)));
            }
        }

        public static AdminRepository repo = new AdminRepository();
        public async Task EmployeesAsync()
        {
            var GetEmployees = await repo.ShowEmployees();
            foreach (var Employee in GetEmployees)
            {
                EmployeesListItem.Add(new MyEmplyeesViewModel() { Name = $"{Employee.Name}" });
            }
        }
        public RelayComand NewEmplyeeButtonClick { get; set; }
        public RelayComand ChangeEmployeeButtonClick { get; set; }
        public EmployesViewModel()
        {
            EmployeesListItem = new ObservableCollection<MyEmplyeesViewModel>();
            ChangeEmployeeButtonClick = new RelayComand(ChangeEmployeeButtonClickEvent);
            NewEmplyeeButtonClick = new RelayComand(NewEmplyeeButtonClickEvent);
            _ = EmployeesAsync();
            MainWindowViewModel.DataCotext.Title = "Arbetare";
        }

        public void ChangeEmployeeButtonClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.ChangeEmployee;

            
            ChangeEmployeeViewModel.Instance.CurrentEmplyee = ((ChangeEmployeeViewModel)parameter);
            
            
        }

        public void NewEmplyeeButtonClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.NewEmplyee;
        }

    }
}
