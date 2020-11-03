using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.ViewModels
{
	public class DeliveriesTasks_ViewModel : INotifyPropertyChanged
	{
		public LogIn_AdministratorViewModel logIn_AdministratorVM;
		public DeliveriesTasks_Model DeliveriesTasks_M;
		
		private string city;
		public string City{get { return city; }set{city = value; OnPropertyChanged("City");}}

		private DateTime selectedDate;
		public DateTime SelectedDate{get { return selectedDate; }set{selectedDate = value; OnPropertyChanged("SelectedDate");}}
		
		private List<Delivery> deliveries;
		public List<Delivery> Deliveries{get { return deliveries; }set{deliveries = value; OnPropertyChanged("Deliveries");}}

		public DeliveriesTask_Command deliveriesTask_CMD;
		public DeliveriesTask_Command DeliveriesTask_CMD { get { return new DeliveriesTask_Command(this); } }

		public IsTaskDone_Command isTaskDone_CMD;
		public IsTaskDone_Command IsTaskDone_CMD { get { return new IsTaskDone_Command(this); } }
		
		public Delivery deliveryDone;
		public Delivery DeliveryDone { get { return deliveryDone; } set { deliveryDone = value; OnPropertyChanged("DeliveryDone"); } }
		
		//Constructors
		public DeliveriesTasks_ViewModel(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			deliveries = new List<Delivery>();
			deliveriesTask_CMD = new DeliveriesTask_Command(this);
			isTaskDone_CMD = new IsTaskDone_Command(this);
			DeliveriesTasks_M = new DeliveriesTasks_Model();
			DeliveryDone = new Delivery();
			selectedDate = DateTime.Now;
			logIn_AdministratorVM = logIn_AdministratorViewModel;
		}

		// Get all the deliveries that were delivered successfully
		public void IsTaskDone()
		{
			DeliveriesTasks_M.IsTaskDone(Deliveries);
			logIn_AdministratorVM.ShowHomePage();
		}

	
		public void SearchByOption()
		{
			if (City != null && SelectedDate != null)
				Deliveries=DeliveriesTasks_M.SearchByCityAndDateTime(City ,SelectedDate);
			if (City == null && SelectedDate != null)
				Deliveries = DeliveriesTasks_M.SearchByDateTime(SelectedDate);
			if (City != null && SelectedDate == null)
				Deliveries = DeliveriesTasks_M.SearchByCity(City);


		}

		// Property Changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));


		}
	}
}
