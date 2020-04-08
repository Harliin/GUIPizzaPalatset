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

		public RelayCommand UpdateOrderStatusCommand { get; set; }

		#region Properties
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
		#endregion

		#region Methods

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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

		#endregion

		#region Default constructor
		public MainViewModel()
		{
			UpdateOrderStatusCommand = new RelayCommand(Update);
			PaidOrders = new ObservableCollection<Order>();
			CookingOrders = new ObservableCollection<Order>();
			ShowAllReadyOrders();
			ShowAllOngoingOrders();
		}

        #endregion
    }
}