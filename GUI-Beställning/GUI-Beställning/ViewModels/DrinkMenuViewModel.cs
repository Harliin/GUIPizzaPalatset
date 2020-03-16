using GUI_Beställning.Models.Data;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace GUI_Beställning.ViewModels
{
    public class DrinkMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "DrinkMenu";

        public IScreen HostScreen { get; }

        #endregion
        
        public OrderRepository repo = new OrderRepository();

        public ObservableCollection<Drink> Drinks { get; set; }

        public DrinkMenuViewModel(IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            var drinksIE = repo.ShowDrinks();
            Drinks = new ObservableCollection<Drink>(drinksIE.ToList());
            
        }

    }
}
