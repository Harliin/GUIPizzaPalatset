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
    class PizzasViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        private ObservableCollection<MyPizzaVieweModel> pizzaListItems;
        public ObservableCollection<MyPizzaVieweModel> PizzaListItems 
        {
            get { return pizzaListItems; }
            set
            { 
                pizzaListItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(PizzaListItems)));



            }


        }
        public static AdminRepository repo = new AdminRepository();
        public async Task PizzaAsync()
        {
       
            var task = await repo.GetPizzas();
            foreach (var item in task)
            {
                PizzaListItems.Add(new MyPizzaVieweModel() { Name = item.Name, Id = item.ID}) ;

            }


        }

        public RelayComand NewPizzaClick { get; set; }

        public RelayComand EditPizzaClick { get; set; }
        public PizzasViewModel()
        {
          
            
            PizzaListItems = new ObservableCollection<MyPizzaVieweModel>();
            _ = PizzaAsync();
           
           
            MainWindowViewModel.DataCotext.Title = "Pizza";
            
            NewPizzaClick = new RelayComand(NewPizzaClickEvent);
            EditPizzaClick = new RelayComand(EditPizzaMenyClickEvent);
        }

        public void EditPizzaMenyClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.EditPizza;

            EditPizzViewModel.Instance.CurrentPizza = ((MyPizzaVieweModel)parameter);

            
        }
        public void NewPizzaClickEvent(object paramter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.NewPizza;
        }

    }
}
