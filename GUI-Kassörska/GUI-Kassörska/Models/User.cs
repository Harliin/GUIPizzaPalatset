using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.Models
{
    public class User : ObservableObject
    {
        private string _userName;
        private string _employeeNumber;
        public string UserName
        {
            get
            {
                return _userName;
            }

            set
            {
                _userName = value;
                OnPropertyChanged(_userName);
            }
        }
        public int EmployeeNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
