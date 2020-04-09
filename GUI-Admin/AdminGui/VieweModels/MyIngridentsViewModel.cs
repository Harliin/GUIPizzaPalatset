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
    public class MyIngridentsViewModel : INotifyPropertyChanged
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
        private int iD { get; set; }
        public int ID
        {
            get { return iD; }
            set
            {
                iD = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ID)));
            }
        }

    }
}
