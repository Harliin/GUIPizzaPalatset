using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.Models
{
    public class User : ObservableObject
    {
        private string userName;
        private string employeeNumber;
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                OnPropertyChanged(userName);
            }
        }
        public int EmployeeNumber { get; set; }
    }
}
