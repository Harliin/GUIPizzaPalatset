using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AdminGui.Models;


namespace AdminGui
{
   public class MyEmplyeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (Sender, e) => { };
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

        private int iD { get; set; }
        public int ID
        {
            get { return iD; }
            set { PropertyChanged(this, new PropertyChangedEventArgs(nameof(ID))); }
        }

    }
}
