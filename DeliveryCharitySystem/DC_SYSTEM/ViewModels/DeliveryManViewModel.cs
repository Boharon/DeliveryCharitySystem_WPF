using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace DC_SYSTEM.ViewModels
{
	public class DeliveryManViewModel : INotifyPropertyChanged
	{
		public DeliveryManModel deliveryMan_M;
		public LogIn_AdministratorViewModel LogIn_AdministratorViewModel;

		public AddDeliveryManCommand addDeliveryManCMD;
		public AddDeliveryManCommand AddDeliveryManCMD { get { return new AddDeliveryManCommand(this); } }
		
		public DeliveryMan deliveryMan;
		public DeliveryMan DeliveryMan { get { return deliveryMan; } set { deliveryMan = value; OnPropertyChanged("IdDeliveryMan"); } }
		
		public List<string> cities = new List<string> { };
		public List<IGrouping<string, string>> streetsGroupedByCity = new List<IGrouping<string, string>>();
		
		//Constructors
		public DeliveryManViewModel()
		{

			deliveryMan = new DeliveryMan() { Address = new Address() };
			addDeliveryManCMD = new AddDeliveryManCommand(this);
			deliveryMan_M = new DeliveryManModel();
			cities = deliveryMan_M.GetCities();
			streetsGroupedByCity = deliveryMan_M.GetstreetsGroupedByCity();
		}
		public DeliveryManViewModel(DeliveryMan MydeliveryMan)
		{

			deliveryMan = MydeliveryMan;
			addDeliveryManCMD = new AddDeliveryManCommand(this);
			deliveryMan_M = new DeliveryManModel();
			cities = deliveryMan_M.GetCities();
			streetsGroupedByCity = deliveryMan_M.GetstreetsGroupedByCity();
		}
		public DeliveryManViewModel(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{

			deliveryMan = new DeliveryMan() { Address = new Address() };
			addDeliveryManCMD = new AddDeliveryManCommand(this);
			deliveryMan_M = new DeliveryManModel();
			cities = deliveryMan_M.GetCities();
			streetsGroupedByCity = deliveryMan_M.GetstreetsGroupedByCity();
			this.LogIn_AdministratorViewModel = logIn_AdministratorViewModel;
		}
		public DeliveryManViewModel(DeliveryMan MydeliveryMan, LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{

			deliveryMan = MydeliveryMan;
			addDeliveryManCMD = new AddDeliveryManCommand(this);
			deliveryMan_M = new DeliveryManModel();
			cities = deliveryMan_M.GetCities();
			streetsGroupedByCity = deliveryMan_M.GetstreetsGroupedByCity();
			this.LogIn_AdministratorViewModel = logIn_AdministratorViewModel;

		}
		

		public void AddDeliveryMan()
		{
			
			deliveryMan_M.Add_DeliveryMan(deliveryMan);
			var result = MessageBox.Show("נשמר בהצלחה !", "אישור", MessageBoxButton.OK, MessageBoxImage.Question);
			if (result == MessageBoxResult.OK)
				LogIn_AdministratorViewModel.ShowHomePage();

		}
		//Property Changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));

		}
	}
}





	
