using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
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
using System.Xml.Linq;

namespace DC_SYSTEM.ViewModels
{
	public class AdultViewModel:INotifyPropertyChanged
	{
		public AdultModel adultM;
		public Adult adult;
		public LogIn_AdministratorViewModel LogIn_AdministratorViewModel;

		public AddAdultCommnd addAdultCMD;
		public AddAdultCommnd AddAdultCMD { get { return new AddAdultCommnd(this); } }
		public Adult Adult { get { return adult; } set {adult = value; OnPropertyChanged("IdAdult"); }}
		
		public  List<string> cities=new List<string> { } ;
		public  List<IGrouping<string, string>> streetsGroupedByCity = new List<IGrouping<string, string>>();
		
		
		//Constructors
		public AdultViewModel()
		{

			adult = new Adult() { Address = new Address() };
			addAdultCMD = new AddAdultCommnd(this);
			adultM = new AdultModel();
			cities = adultM.GetCities();
			streetsGroupedByCity= adultM.GetstreetsGroupedByCity();
		}
		public AdultViewModel(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{

			adult = new Adult() { Address = new Address() };
			addAdultCMD = new AddAdultCommnd(this);
			adultM = new AdultModel();
			cities = adultM.GetCities();
			streetsGroupedByCity = adultM.GetstreetsGroupedByCity();
			this.LogIn_AdministratorViewModel = logIn_AdministratorViewModel;
		}
		public AdultViewModel(Adult adulty,LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{

			adult = adulty;
			addAdultCMD = new AddAdultCommnd(this);
			adultM = new AdultModel();
			cities = adultM.GetCities();
			streetsGroupedByCity = adultM.GetstreetsGroupedByCity(); 
			this.LogIn_AdministratorViewModel = logIn_AdministratorViewModel;
		}
		
		public AdultViewModel(Adult adulty)
		{
			adult = adulty;
			adult.Address = adulty.Address;
			addAdultCMD = new AddAdultCommnd(this);
			adultM = new AdultModel();
			cities = adultM.GetCities();
			streetsGroupedByCity = adultM.GetstreetsGroupedByCity();
		}

		// PropertyChanged
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
				if (PropertyChanged != null)
					PropertyChanged
						(this, new PropertyChangedEventArgs(propertyName));

	
		}
		// Add Adult
		public void AddAdult()
		{
			
		   adultM.Add_Adult(adult);
			var result = MessageBox.Show("נשמר בהצלחה !", "אישור", MessageBoxButton.OK, MessageBoxImage.Information);
			if (result == MessageBoxResult.OK)
				LogIn_AdministratorViewModel.ShowHomePage();


		}
	}
}
