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
    class OvrightVewmodel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private ObservableCollection<MyOvrigtViewModel> ovrigtListItem;
        public ObservableCollection<MyOvrigtViewModel> OvrigtListItem
        {
            get { return ovrigtListItem; }
            set
            {
                ovrigtListItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(OvrigtListItem)));
            }

        }
            public static AdminRepository repo = new AdminRepository();
        public async Task GetOvrigtAsync()

        {
            var GetDrinks = await repo.ShowDrinksAsync();
            foreach (var item in GetDrinks)
            {
                OvrigtListItem.Add(new MyOvrigtViewModel() { Name = $"{item.Name}" });
            }
            var GetPastas = await repo.ShowPastasAsync();
            foreach (var item in GetPastas)
            {
                OvrigtListItem.Add(new MyOvrigtViewModel() { Name = $"{item.Name}" });
            }
            var GetSallads = await repo.ShowSalladsAsync();
            foreach (var item in GetSallads)
            {
                ovrigtListItem.Add(new MyOvrigtViewModel() { Name = $"{item.Name}" });

            }
        }

      
        public RelayComand NewOvritButtonClick { get; set; }
        public OvrightVewmodel()
        {
            OvrigtListItem = new ObservableCollection<MyOvrigtViewModel>();
            _ = GetOvrigtAsync();
          
             MainWindowViewModel.DataCotext.Title = "Övrigt";
            NewOvritButtonClick = new RelayComand(NewOvritButtonClickEvent);

        }
        public void NewOvritButtonClickEvent(object parameter) 
        {
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.NewOvrigt;
        }

    }
}
