using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Beställning.ViewModels
{
    public class ReceiptViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "ReceiptView";

        public IScreen HostScreen { get; }

        #endregion

        #region Properties
        public static MainWindowViewModel MainWindowViewModel;
        public ObservableCollection<object> RecieptFoods => MainWindowViewModel.Order;
        public int OrderID => MainWindowViewModel.OrderID;
        public double SEKPrice => MainWindowViewModel.TotalPrice;

        public double EuroPrice { get; set; }

        #endregion

        #region Commands
        public RelayCommand CheckoutCommand { get; set; }
        #endregion

        public ReceiptViewModel(MainWindowViewModel viewModel = null,IScreen screen = null)
        {
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();

            if (MainWindowViewModel == null)
            {
                MainWindowViewModel = viewModel;
            }
            EuroRateAsync();
            CheckoutCommand = new RelayCommand(MainWindowViewModel.CheckoutCommandMethod);
        }
   
        public void EuroRateAsync()
        {
           
            ExchangeRates rates = new ExchangeRates();
            using (WebClient webClient = new WebClient())
            {
                string uri = "https://api.exchangeratesapi.io/latest?symbols=SEK";
                webClient.BaseAddress = uri;
                var json = webClient.DownloadString(uri);
                rates = System.Text.Json.JsonSerializer.Deserialize<ExchangeRates>(json);
            }

            if(rates.Rates.TryGetValue("SEK", out float rate))
            {
                EuroPrice = Math.Round((SEKPrice / rate),2);
            }
        }
    }
}
