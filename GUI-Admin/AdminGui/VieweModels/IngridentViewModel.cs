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
   class IngridentViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public RelayComand IngredientChoiseClick { get; set; }
        private ObservableCollection<MyIngridentsViewModel> ingridentsListItem;
        public ObservableCollection<MyIngridentsViewModel> IngridentsListItem
        {
            get { return ingridentsListItem; }
            set
            {
                ingridentsListItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IngridentsListItem)));
            }
        }

        public static AdminRepository repo = new AdminRepository();

        public async Task IngidentAsync()
        {
            var task = await repo.ShowIngredientsAsync();
            foreach (var item in task)
            {
                IngridentsListItem.Add(new MyIngridentsViewModel() { Name = $"{item.Name}" });
            }
        }
        public async Task InGrenetOnPizzaAsync()
        {
            await repo.ShowPizzaAndIngredients();
        }


        public IngridentViewModel()
        {
            IngridentsListItem = new ObservableCollection<MyIngridentsViewModel>();
            IngredientChoiseClick = new RelayComand(IngredientChoiseClickEvent);
            _ = IngidentAsync();
            
            MainWindowViewModel.DataCotext.Title = "Ingridents";
        }

        public void IngredientChoiseClickEvent(object paramter)
        {

        }

    }
}
