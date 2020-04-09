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
    public class NewOvrigtViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private bool dryck { get; set; }
        public bool Dryck {
            get { return dryck; }
            set {
                dryck = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Dryck))); 
                 
            }
        }
        private bool pasta { get; set; }
        public bool Pasta
        {
            get { return pasta; }
            set
            {
                pasta = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Pasta)));

            }
        }
        private bool sallad { get; set; }
        public bool Sallad
        {
            get { return sallad; }
            set
            {
                sallad = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Sallad)));

            }
        }
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
        private int price { get; set; }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Price)));

            }

        }
        public static AdminRepository repo = new AdminRepository();

        public async Task AddOvrigtAsync()
        {

            if (Dryck)
            {
                await repo.AddDrinkAsync(Name, Price);
            }
            else if (Pasta)
            {
                await repo.AddPastaAsync(Name, Price);
            }
            else if (Sallad)
            {
                await repo.AddSalladAsync(Name, Price);
            }
        }
        public RelayComand CreatOvrigtButtonClick { get; set; }
            public NewOvrigtViewModel()
        {
            MainWindowViewModel.DataCotext.Title = "Ny Övrigt";
            CreatOvrigtButtonClick = new RelayComand(CreatOvrigtButtonClickEvent);
        }

        public void CreatOvrigtButtonClickEvent(object parameter)
        {
           _= AddOvrigtAsync();
            MainWindowViewModel.DataCotext.CurrentPage = MenyePages.Ovrigt;

        }
    }
}
