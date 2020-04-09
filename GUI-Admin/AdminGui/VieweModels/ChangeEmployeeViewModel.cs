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
    public class ChangeEmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public static ChangeEmployeeViewModel Instance { get; set; }

        public static AdminRepository repo = new AdminRepository();

        public async Task EmplyeeAsync()
        {
            var GetEmplyees = await repo.ShowEmployees();
            foreach (var item in GetEmplyees)
            {
                
            }
        }
        private ChangeEmployeeViewModel currentEmplyee;
        public ChangeEmployeeViewModel CurrentEmplyee
        {
            get { return currentEmplyee; }
            set
            {
                currentEmplyee = value;
                
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentEmplyee)));
            }
        }

        
    }
}
