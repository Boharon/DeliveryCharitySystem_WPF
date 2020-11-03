using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using DC_SYSTEM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DC_SYSTEM.ViewModels
{

	public class Search_ViewModel: INotifyPropertyChanged
	{
		public LogIn_AdministratorViewModel LogIn_AdministratorVM;
		public SearchDeliverMan_UserCntrl SearchDeliverMan_UserCntrlV;
		public SearchAdult_UserCntrl SearchAdult_UserCntrlV;
		public Search_Model search_M;
		public string action;
		
		private string id;
		public string Id { get { return id; } set { id = value; OnPropertyChanged("Id"); } }
		
		private string name;
		public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }
		
		private string city;
		public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }

		private List <DeliveryMan> delivermen;
		public List<DeliveryMan> Delivermen { get { return delivermen; } set { delivermen = value; OnPropertyChanged("Delivermen"); } }

		private List<Adult> adults;
		public List<Adult> Adults { get { return adults; } set { adults = value; OnPropertyChanged("Adults"); } }

		private Search_Command search_CMD;
		public Search_Command Search_CMD { get { return new Search_Command(this); } }

		private Search_Update_Command search_Update_CMD;
		public Search_Update_Command Search_Update_CMD { get { return new Search_Update_Command(this); } }
		
		private DeliveryMan deliveryMan;
		public DeliveryMan DeliveryMan{ get { return deliveryMan; } set { deliveryMan = value; OnPropertyChanged("DeliveryMan"); } }

		private Adult adult;
		public Adult Adult{ get { return adult; } set { adult = value; OnPropertyChanged("Adult"); } }

		//Constructors
		//Constructor in order to search a delivery man
		public Search_ViewModel(SearchDeliverMan_UserCntrl mySearchDeliverMan_UserCntrlV, LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			search_CMD = new Search_Command(this);
			search_Update_CMD = new Search_Update_Command(this);
			search_M = new Search_Model();
			delivermen = new List<DeliveryMan>();
			SearchDeliverMan_UserCntrlV = mySearchDeliverMan_UserCntrlV;
			LogIn_AdministratorVM = logIn_AdministratorViewModel;
		}

		//Constructor in order to search an adult
		public Search_ViewModel(SearchAdult_UserCntrl mySearchAdult_UserCntrlV, LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			search_CMD = new Search_Command(this);
			search_Update_CMD = new Search_Update_Command(this);
			search_M = new Search_Model();
			adults = new List<Adult>();
			SearchAdult_UserCntrlV = mySearchAdult_UserCntrlV;
			LogIn_AdministratorVM = logIn_AdministratorViewModel;
		}


		
		//Updating delivery man details
		public void Update()
		{
			SearchDeliverMan_UserCntrlV.addUC(DeliveryMan, LogIn_AdministratorVM);
			
		}
		//Updating adult details
		public void UpdateAdult()
		{
			SearchAdult_UserCntrlV.addUC(Adult, LogIn_AdministratorVM);
			
		}

		public void SearchDeliverManByName()
		{
			Id = null;
			City = null;
			Delivermen=search_M.SearchDeliverManByName(name).ToList();
		}

		public void SearchDeliverManById()
		{
			Name = null;
			City = null;
			Delivermen=search_M.SearchDeliverManById(id).ToList();
		}
		public void SearchDeliverManByCity()
		{
			Name = null;
			Id = null;
			Delivermen = search_M.SearchDeliverManByCity(city).ToList();
		}

		public void SearchAdultByName()
		{
			Id = null;
			City = null;
			Adults =search_M.SearchAdultByName(name).ToList();
		}

		public void SearchAdultById()
		{
			Name = null;
			City = null;
			Adults =search_M.SearchAdultById(id).ToList();
		}

		public void SearchAdultByCity()
		{
			Name = null;
			Id = null;
			Adults =search_M.SearchAdultByCity(city).ToList();
		}
		
		// Property changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));


		}
	}

}
