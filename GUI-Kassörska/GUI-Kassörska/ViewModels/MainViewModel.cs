using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace GUI_Kassörska.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged // ObservableObject
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		private IEnumerable databaseList;

		public IEnumerable DatabaseList
		{
			get { return databaseList; }
			set
			{
				databaseList = value;
				OnPropertyChanged("DatabaseList");
			}
		}

		private ObservableCollection<Order> ongoingOrders;

		public ObservableCollection<Order> OngoingOrders
		{
			get { return ongoingOrders; }
			set
			{
				ongoingOrders = value;
				OnPropertyChanged("OngoingOrders");
			}
		}

		private Order currentOrder;

		public Order CurrentOrder
		{
			get { return currentOrder; }
			set
			{
				currentOrder = value;
				OnPropertyChanged("CurrentOrder");
			}
		}

		private int status;

		public int Status
		{
			get { return status; }
			set
			{
				status = value;
				OnPropertyChanged("Status");
			}
		}

		private int orderID;

		public int OrderID
		{
			get { return orderID; }
			set
			{
				orderID = value;
				OnPropertyChanged("OrderID");
			}
		}

		public async Task<ObservableCollection<Order>> ShowAllOngoingOrders()
		{
			DatabaseList = await repo.ShowAllOrders();
			OngoingOrders = new ObservableCollection<Order>();
			foreach(Order item in DatabaseList)
			{
				Order order = new Order();
				order.OrderID = item.OrderID;
				order.Status = item.Status;
				OngoingOrders.Add(order);
			}
			return OngoingOrders;
		}

		public MainViewModel()
		{
			ShowAllOngoingOrders();
		}

		public CashierRepository repo = new CashierRepository();

		


		//public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		//public CashierRepository repo = new CashierRepository();

		//public ObservableCollection<Order> Orders { get; set; }
		//private string orderString;

		//public MainViewModel()
		//{
		//	var OrderIE = repo.ShowAllOrders();
		//	Orders = new ObservableCollection<Order>(OrderIE.ToList());
		//}

		//public string OrderString
		//{
		//	get { return orderString; }
		//	set 
		//	{
		//		orderString = value;
		//		PropertyChanged(this, new PropertyChangedEventArgs(nameof(OrderString)));

		//	}
		//}

	}
}