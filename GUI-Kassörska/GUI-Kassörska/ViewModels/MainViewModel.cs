using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using GUI_Kassörska.Command;
using static GUI_Kassörska.ViewModels.Order;

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

		public RelayCommand Serve { get; set; }

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

		private ObservableCollection<Order> readyOrders;

		public ObservableCollection<Order> ReadyOrders
		{
			get { return readyOrders; }
			set
			{
				readyOrders = value;
				OnPropertyChanged("ReadyOrders");
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
				OrderID = CurrentOrder.OrderID;
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

		public async Task<ObservableCollection<Order>> ShowAllReadyOrders()
		{
			DatabaseList = await repo.ShowOrderByStatusAsync(Order.eStatus.Klar);
			ReadyOrders = new ObservableCollection<Order>();
			foreach (Order item in DatabaseList)
			{
				Order order = new Order();
				order.OrderID = item.OrderID;
				order.Status = item.Status;
				ReadyOrders.Add(order);
			}

			return ReadyOrders;
		}

		public async Task<ObservableCollection<Order>> ShowAllOngoingOrders()
		{
			DatabaseList = await repo.ShowOrdersWithStatusOneAndTwo();
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

		private async void Update(object u)
		{
			await repo.UpdateOrderStatus(OrderID);
			await ShowAllReadyOrders();
		}

		public Task<int> GetOrderStatus(int orderNumber)
		{
			var orderStatus = repo.ShowOrderByID(orderNumber);

			return orderStatus;
		}

		public MainViewModel()
		{
			//ShowAllOngoingOrders();
			ShowAllReadyOrders();

			Serve = new RelayCommand(Update);
		}

		public CashierRepository repo = new CashierRepository();
	}
}