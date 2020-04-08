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
using GUI_Kassörska.Models.Data;
using System.Net;

namespace GUI_Kassörska.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public CashierRepository repo = new CashierRepository();

		public void OnPropertyChanged(string propertyName)
		{
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public RelayCommand UpdateOrderStatusCommand { get; set; }

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

		public double EuroPrice { get; set; }

		public ObservableCollection<Order> PaidOrders { get; set; }

		public ObservableCollection<Order> CookingOrders { get; set; }

		private Order currentOrder;

		public Order CurrentOrder
		{
			get { return currentOrder; }
			set
			{
				if (currentOrder == value || value == null)
					return;

				currentOrder = value;

				if (currentOrder.ID != 0)
					ID = currentOrder.ID;

				OnPropertyChanged("CurrentOrder");
			}
		}

		public int Status { get; set; }

		private int id;

		public int ID
		{
			get { return id; }
			set
			{
				id = value;
				OnPropertyChanged("ReadyOrders");
			}
		}


		public ObservableCollection<Order> ShowAllReadyOrders()
		{
			DatabaseList = repo.ShowOrderByStatus(Order.eStatus.Klar);
			ReadyOrders = new ObservableCollection<Order>();
			foreach (Order item in DatabaseList)
			{
				Order order = new Order();
				order.ID = item.ID;
				order.Status = item.Status;
				ReadyOrders.Add(order);
			}

			return ReadyOrders;
		}

		public void ShowAllOngoingOrders()
		{
			//DatabaseList = await repo.ShowOrdersWithStatusOneAndTwo();
			//OngoingOrders = new ObservableCollection<Order>();
			//foreach(Order item in DatabaseList)
			//{
			//	Order order = new Order();
			//	order.OrderID = item.OrderID;
			//	order.Status = item.Status;
			//	OngoingOrders.Add(order);
			//}

			//return OngoingOrders;

			var list = repo.ShowAllOrders().ToList();

			list.ForEach(item => 
			{
				if (item.Status == eStatus.UnderBeställning)
				{
					PaidOrders.Add(item);
				}
				else if(item.Status == eStatus.Tillagning)
				{
					CookingOrders.Add(item);
				}	 
			});
		}

		public int GetOrderStatus(int orderNumber)
		{
			var orderStatus = repo.ShowOrderByID(orderNumber);

			return orderStatus;
		}

		private void Update(object u)
		{
			Order order = (Order)u;
			repo.UpdateOrderStatus(order.ID);
			ShowAllReadyOrders();
		}

		//public void EuroRate()
		//{
		//	float SEKPrice = 10;
		//	ExchangeRates rates = new ExchangeRates();
		//	using (WebClient webClient = new WebClient())
		//	{
		//		string uri = "https://api.exchangeratesapi.io/history?start_at=2018-01-01&end_at=2018-09-01&symbols=EUR";
		//		webClient.BaseAddress = uri;
		//		var json = webClient.DownloadString(uri);
		//		rates = System.Text.Json.JsonSerializer.Deserialize<ExchangeRates>(json);
		//	}

		//	if (rates.Rates.TryGetValue("SEK", out float rate))
		//	{
		//		EuroPrice = Math.Round((SEKPrice / rate), 2);
		//	}
		//}

		public MainViewModel()
		{
			UpdateOrderStatusCommand = new RelayCommand(Update);
			PaidOrders = new ObservableCollection<Order>();
			CookingOrders = new ObservableCollection<Order>();
			//ShowAllOngoingOrders();
			ShowAllReadyOrders();
			ShowAllOngoingOrders();
			
		}
	}
}