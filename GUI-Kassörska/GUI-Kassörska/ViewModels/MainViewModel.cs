using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace GUI_Kassörska.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged // ObservableObject
	{
		public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

		private string orderString;

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