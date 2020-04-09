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
   public class MyPizzaVieweModel:INotifyPropertyChanged
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

        private int id { get; set; }
        public int Id 
        {
            get { return id; }
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }
        private ObservableCollection<MyIngrident> ingredients;
        public ObservableCollection<MyIngrident> Ingredients
        {
            get { return ingredients; }
            set {
                ingredients = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Ingredients)));
                }
        }
      
        public override string ToString()
        {

            return this.Name;
        }

    }
}
