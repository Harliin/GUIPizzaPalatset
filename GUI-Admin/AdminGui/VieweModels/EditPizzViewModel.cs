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
    public class EditPizzViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public static  EditPizzViewModel Instance { get; set; }

        private ObservableCollection<MyIngridentsViewModel> ingridientListItems;
        public ObservableCollection<MyIngridentsViewModel> IngridientListItems
        {
            get { return ingridientListItems; }
            set
            {
                ingridientListItems = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IngridientListItems)));

            }

        }
        public static AdminRepository repo = new AdminRepository();
      



        public async Task IngridentAsync()
        {

            var task = await repo.ShowIngredientsAsync();
           
            foreach (var item in task)
            {
                IngridientListItems.Add(new MyIngridentsViewModel() { Name = item.Name, ID = item.ID });

            }
        }
    
       


        private MyPizzaVieweModel currentpizza;
        public MyPizzaVieweModel CurrentPizza 
        {
        get { return currentpizza; }
            set 
            {
                currentpizza = value;
                MainWindowViewModel.DataCotext.Title = value.Name;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentPizza)));
            }
        }
        public async Task RemovePizzaAsync()
        {
            await repo.DeletePizzaAsync(currentpizza.Id);
        }
        public async Task AddIngidentToPizzaAsync(Ingredient i)
        {

            await repo.AddIngredientToPizzaAsync(currentpizza.Id, new int[] { i.ID });
        }
        public RelayComand RemovePizzaButtonClick { get; set; }

        public RelayComand EditPizzaClick { get; set; }
        public RelayComand EditPizzaConfirmClick { get; set; }
        public EditPizzViewModel()
        {
            IngridientListItems = new ObservableCollection<MyIngridentsViewModel>(); 
            _ = IngridentAsync();
            Instance = this;
            RemovePizzaButtonClick = new RelayComand(RemovePizzaButtonClickEvent);
            EditPizzaClick = new RelayComand(EditPizzaClickEvent);
            EditPizzaConfirmClick = new RelayComand(EditPizzaConfirmClickEvent);
        }
        public void RemovePizzaButtonClickEvent(object parameter)
        {
            _ = RemovePizzaAsync();
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.PizzaMenu;
        }
        public async void EditPizzaClickEvent(object parameter)
        {
            Ingredient i = new Ingredient() { ID = ((MyIngridentsViewModel) parameter).ID};
            await AddIngidentToPizzaAsync(i);
        }
        public void EditPizzaConfirmClickEvent(object parameter)
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.PizzaMenu;
        }



    }
}
