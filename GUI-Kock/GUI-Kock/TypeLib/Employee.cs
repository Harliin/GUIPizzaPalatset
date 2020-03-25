using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Food
{
    public class Employee: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public int ID { get; set; }

        private string Name { get; set; }
        private string Password { get; set; }

        public enum EmployeeType { VD = 1, Bagare = 2, Kassörska = 3 }



        /// <summary>
        /// Gets or sets new admin name
        /// </summary>
        public string name
        {
            get
            {
                return Name;
            }

            set
            {
                name = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(name)));
            }
        }

        public string password
        {
            get
            {
                return Password;
            }

            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(password)));
            }
        }
    }
}
