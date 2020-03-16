using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GUI_Kassörska.Models
{
    public class User : INotifyPropertyChanged
    {
        private string userName;
        private string employeeNumber;
        public string UserName {
            get
            {
                return userName;
            };
            set
            {
                
            }; }
        public int EmployeeNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
