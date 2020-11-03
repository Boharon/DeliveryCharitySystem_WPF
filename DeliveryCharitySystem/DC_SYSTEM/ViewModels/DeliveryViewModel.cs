using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;

namespace DC_SYSTEM.ViewModels
{
	public class DeliveryViewModel: INotifyPropertyChanged 
	{
		public LogIn_AdministratorViewModel LogIn_AdministratorViewModel;
		public DeliveryModel deliveryM;
		
		public Delivery delivery;
		public Delivery Delivery { get { return delivery; } set { delivery = value; } }

		private List<Adult> selectedAdultsList;
		public List<Adult> SelectedAdultsList{get { return selectedAdultsList; }set {selectedAdultsList = value; OnPropertyChanged("SelectedAdultsList");} }
		
		public List<DeliveryMan> selectedDeliveryMansList;
		public List<DeliveryMan> SelectedDeliveryMansList{get { return selectedDeliveryMansList; }set{selectedDeliveryMansList = value; OnPropertyChanged("SelectedDeliveryMansList");}}
	
		private List<Adult> adultsByCityList;
		public List<Adult> AdultsByCityList{get { return adultsByCityList; }set {adultsByCityList = value; OnPropertyChanged("AdultsByCityList"); } }
		
		private List<DeliveryMan> deliveryMansList;
		public List<DeliveryMan> DeliveryMansList{	get { return deliveryMansList; }set{	deliveryMansList = value; OnPropertyChanged("DeliveryMansList");}}
	
		private ImageSource imageSource;
		public ImageSource ImageSource { get { return imageSource; } set { imageSource = value; OnPropertyChanged("ImageSource"); } }

		public AddDeliveryButton addDelivery_btn_CMD;
		public AddDeliveryButton AddDelivery_btn_CMD { get { return new AddDeliveryButton(this); } }
		
		public AddDeliveryButton removeDelivery_btn_CMD;
		public AddDeliveryButton RemoveDelivery_btn_CMD { get { return new AddDeliveryButton(this); } }

		public CityActionCommand cityActionCMD;
		public CityActionCommand CityActionCMD { get { return new CityActionCommand(this); } }

		private BtnOfMenu_Command btn_CMD;
		public BtnOfMenu_Command Btn_CMD { get { return new BtnOfMenu_Command(LogIn_AdministratorViewModel); } }

		public Adult adult;
		public Adult Adult { get { return adult; } set { adult = value; OnPropertyChanged("Adult"); } }
		
		public DeliveryMan deliveryMan;
		public DeliveryMan DeliveryMan { get { return deliveryMan; } set { deliveryMan = value; OnPropertyChanged("DeliveryMan"); } }
		
		public int addIndex;
		public int AddIndex{	get { return addIndex; }set{	addIndex = value; OnPropertyChanged("AddIndex");}}
	
		public int removeIndex;
		public int RemoveIndex{get { return removeIndex; }set{	removeIndex = value; OnPropertyChanged("RemoveIndex");}}

		public int addDeliveryManIndex;
		public int AddDeliveryManIndex{	get { return addDeliveryManIndex; }set{	addDeliveryManIndex = value; OnPropertyChanged("AddDeliveryManIndex");}}
	
		public int removeDeliveryManIndex;
		public int RemoveDeliveryManIndex{	get { return removeDeliveryManIndex; }set{	removeDeliveryManIndex = value; OnPropertyChanged("RemoveDeliveryManIndex");}}

		private DateTime selectedDate;
		public DateTime SelectedDate { get { return selectedDate; } set { selectedDate = value; OnPropertyChanged("SelectedDate"); } }
		
		private string city;
		public string City { get { return city; } set { city = value; OnPropertyChanged("City"); } }
		public List<string> cities = new List<string> { };
		
		

	
		
		

		
		
		
		//Constructors
		public DeliveryViewModel(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			adult = new Adult();
			deliveryM = new DeliveryModel();
			delivery = new Delivery();
			addDelivery_btn_CMD = new AddDeliveryButton(this);
			//removeDelivery_btn_CMD = new RemoveDeliveryButton(this);
			cityActionCMD = new CityActionCommand(this);
			SelectedAdultsList = new List<Adult>();
			SelectedDeliveryMansList = new List<DeliveryMan>();
			AdultsByCityList = new List<Adult>();
			DeliveryMansList = deliveryM.Get_All_DeliveryMans();
			string cityPath = @"..\..\..\Cities and Streets xml\CitiesList.xml";
			XElement citiesRoot = XElement.Load(cityPath);
			cities = (from item in citiesRoot.Elements() select item.Value).ToList();
			this.LogIn_AdministratorViewModel = logIn_AdministratorViewModel;
			btn_CMD = new BtnOfMenu_Command(LogIn_AdministratorViewModel);
			selectedDate = DateTime.Now;

		}
	
		public DeliveryViewModel()
		{
			adult = new Adult();
			deliveryM = new DeliveryModel();
			delivery = new Delivery();
			addDelivery_btn_CMD = new AddDeliveryButton(this);
			cityActionCMD = new CityActionCommand(this);
			SelectedAdultsList = new List<Adult>();
			SelectedDeliveryMansList = new List<DeliveryMan>();
			AdultsByCityList = new List<Adult>();
			DeliveryMansList = deliveryM.Get_All_DeliveryMans();
			string cityPath = @"..\..\..\Cities and Streets xml\CitiesList.xml";
			XElement citiesRoot = XElement.Load(cityPath);
			cities = (from item in citiesRoot.Elements() select item.Value).ToList();
			selectedDate = DateTime.Now;
		}

		public void AddButtonClick()
		{
		
			SelectedAdultsList.Add(adult);
			SelectedAdultsList =new List<Adult>( SelectedAdultsList);
			if (AdultsByCityList != null)
			{
				
				AdultsByCityList.RemoveAt(addIndex);
				AdultsByCityList =new List<Adult>( AdultsByCityList);
				
			}
				

		}
		
		public void AddDeliveryManButtonClick()
		{
			
			SelectedDeliveryMansList.Add(deliveryMan);
			SelectedDeliveryMansList = new List<DeliveryMan>(selectedDeliveryMansList);
			if (deliveryMansList != null)
			{
				
				DeliveryMansList.RemoveAt(addDeliveryManIndex);
				DeliveryMansList = new List<DeliveryMan>(DeliveryMansList);

			}
		}
		public void RemoveButtonClick()
		{

			AdultsByCityList.Add(adult);
			AdultsByCityList = new List<Adult>(AdultsByCityList);

			if (SelectedAdultsList != null)
			{

				SelectedAdultsList.RemoveAt(removeIndex);
				SelectedAdultsList = new List<Adult>(SelectedAdultsList);

			}
		}

		public void RemoveDeliveryManButtonClick()
		{
			
			DeliveryMansList.Add(deliveryMan);
			DeliveryMansList = new List<DeliveryMan>(DeliveryMansList);

			if (SelectedDeliveryMansList != null)
			{
				
				SelectedDeliveryMansList.RemoveAt(removeDeliveryManIndex);
				SelectedDeliveryMansList = new List<DeliveryMan>(SelectedDeliveryMansList);
			}
		}
		public void upDateByCityList()
		{
			if (City != null)
			{
				AdultsByCityList = deliveryM.GetAdultsByCity(City);
			}
		}

		// Division into clustres by using K MEANS algorithm
		public void DivisionIntoClusters()
		{

			List<Delivery>[] grupByDeliveryMen;
			grupByDeliveryMen = deliveryM.DivisionIntoClusters(selectedAdultsList, selectedDeliveryMansList, selectedDeliveryMansList.Count, SelectedDate);
			String mapImageUrl = deliveryM.mapImageUrl(City, SelectedDate);
			var converter = new ImageSourceConverter();
			ImageSource = (ImageSource)converter.ConvertFromString(mapImageUrl);

		}


		// Property Changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));
			}

		}


	}
}


