﻿using GUI_Beställning.Models.Data;
using GUI_Beställning.ViewModels.Commands;
using ReactiveUI;
using Splat;
using System.Collections.ObjectModel;
using System.Linq;


namespace GUI_Beställning.ViewModels
{
    public class PastaMenuViewModel : ReactiveObject, IRoutableViewModel
    {
        #region For Reactive UI
        public string UrlPathSegment => "PastaMenu";

        public IScreen HostScreen { get; }

        #endregion

        public OrderRepository repo = new OrderRepository();

        public MainWindowViewModel MainWindowViewModel = new MainWindowViewModel();
        public ObservableCollection<Pasta> Pastas { get; set; }
        public RelayCommand AddPastaCommand { get; set; }

        PaymentViewModel Payment;

        public PastaMenuViewModel(IScreen screen = null)
        {
            AddPastaCommand = new RelayCommand(AddPastaToOrder);
            HostScreen = screen ?? Locator.Current.GetService<IScreen>();
            var PastaIE = repo.ShowPastas();
            Pastas = new ObservableCollection<Pasta>(PastaIE.ToList());
            Payment = new PaymentViewModel();
        }

        private void AddPastaToOrder(object Pasta)
        {
            Pasta pasta = (Pasta)Pasta;
            repo.AddPastaToOrder(MainWindowViewModel.OrderID, pasta.ID);
            Payment.Foods = new ObservableCollection<object>();
        }
    }
}
