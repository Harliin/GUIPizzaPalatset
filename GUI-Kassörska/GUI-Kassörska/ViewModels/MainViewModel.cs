using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace GUI_Kassörska.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged // ObservableObject
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		public CashierRepository repo = new CashierRepository();

		public ObservableCollection<Order> Orders { get; set; }
		private string orderString;

		public MainViewModel()
		{
			var OrderIE = repo.ShowAllOrders();
			Orders = new ObservableCollection<Order>(OrderIE.ToList());
		}

		public string OrderString
		{
			get { return orderString; }
			set 
			{
				orderString = value;
				PropertyChanged(this, new PropertyChangedEventArgs(nameof(OrderString)));

			}
		}

	}
}