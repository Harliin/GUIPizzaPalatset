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
    public class NewEmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private string password { get; set; }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }

        private bool workPlaceBagare { get; set; }
        public bool WorkPlaceBagare
        {
            get { return workPlaceBagare; }
            set
            {
                workPlaceBagare = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(WorkPlaceBagare)));
            }
        }
        
        public static AdminRepository repo = new AdminRepository();

        public async Task CreatNewEmployeeAsync()
        {
            int x = 1;
            if (WorkPlaceBagare)
            {
                x = 2;
            }
            else
            {
                x = 3;
            }
            await repo.AddEmployee(Name, password, x);
        }
        public RelayComand CreateEmployeeButonClick { get; set; }
        public NewEmployeeViewModel()
        {
            MainWindowViewModel.DataCotext.Title = "Ny Anställd";
            CreateEmployeeButonClick = new RelayComand(CreateEmployeeButonClickEvent);
        }
        public void CreateEmployeeButonClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.Emplyees;
            _ = CreatNewEmployeeAsync();
        }
    }
}
