using Accord.Math;
using DC_SYSTEM._BE;
using DC_SYSTEM.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DC_SYSTEM.BLL
{
	public class BL_IMP
	{

		// A function that receives an address and returns the latitude and longitude of the address

		public double[] GetLatLongFromAddress(Address address)
		{
			return new AddressVertification().GetLatLongFromAddress(address);
		}

		// The function returns all the deliveries that were not delivered yet 
		public List<Delivery> Get_AllDeliveriesUnDone()
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisdelivery = from ad in myDeliveries
							   where !(ad.IsDone)
							   select ad;
			return thisdelivery.ToList();
		}

		// The function returns all the deliveries that were delivered successfully 
		public List<Delivery> Get_AllDeliveriesDone()
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisdelivery = from ad in myDeliveries
							   where ad.IsDone
							   select ad;
			return thisdelivery.ToList();
		}

		// The function defines the deliveries that were deliverd successfully as "done"
		public void IsTaskDone(List<Delivery> Deliveries)
		{
			new DAL_IMP().IsTaskDone(Deliveries);
		}

		//The function return list of adults by parameter of name 
		public IEnumerable<Adult> SearchAdultByName(string name)
		{
			IEnumerable<Adult> myAdults = new List<Adult>();
			myAdults = Get_all_Adults();
			var thisName = from ad in myAdults
						   let myName = ad.FirstName
						   where myName.Equals(name)
						   select ad;
			return thisName;

		}
		//The function return list of adults by parameter of id
		public IEnumerable<Adult> SearchAdultById(string id)
		{
			IEnumerable<Adult> myAdults = new List<Adult>();
			myAdults = Get_all_Adults();
			var thisId = from ad in myAdults
						 let myId = ad.Id
						 where myId.Equals(id)
						 select ad;
			return thisId;
		}
		//The function return list of adults by parameter of city
		public IEnumerable<Adult> SearchAdultByCity(string city)
		{
			IEnumerable<Adult> myAdults = new List<Adult>();
			myAdults = Get_all_Adults();
			var thisCity = from ad in myAdults
						   let myCity = ad.Address.City
						   where myCity.Equals(city)
						   select ad;
			return thisCity;
		}
		// The function adds an adult to the adults list (data base)
		public void Add_Adult(Adult adult)
		{
			new DAL_IMP().Add_Adult(adult);
		}

		//The function returns list of all adults
		public List<Adult> Get_all_Adults()
		{
			return new DAL_IMP().Get_all_Adults();
		}
		//The function returns list of all deliveries
		public IEnumerable<Delivery> Get_all_Deliveries()
		{
			return new DAL_IMP().Get_all_Deliveries();
		}
		//The function returns list of all delivery men
		public IEnumerable<DeliveryMan> Get_all_DeliveryMans()
		{
			return new DAL_IMP().Get_all_DeliveryMans();
		}
		//The function returns list of all addresses
		public IEnumerable<Address> Get_all_Address()
		{
			return new DAL_IMP().Get_all_Address();
		}

		//The function returns list of addresses by parameter city
		public IEnumerable<Address> GetAddressByCity(string city)
		{
			IEnumerable<Address> myAddress = new List<Address>();
			List<Address> result = new List<Address>();
			myAddress = Get_all_Address();
			foreach (var address in myAddress)
			{
				if (address.City == city)
				{
					result.Add(address);
				}
			}
			return result;
		}

		//The function return list of  adults by parameter city
		public IEnumerable<Adult> GetAdultsByCity(string city)
		{
			List<Adult> myAdult = new List<Adult>();
			myAdult = Get_all_Adults();

			List<Adult> result = new List<Adult>();

			List<Address> myAddress2 = GetAddressByCity(city).ToList();
			foreach (var adult in myAdult)
			{
				foreach (var address in myAddress2)
				{
					if (adult.Address.AddressID.CompareTo(address.AddressID) == 0)
					{
						result.Add(new Adult(adult));
					}
				}

			}
			return result;
		}
		//The function return list of delivery men by parameter of city
		public IEnumerable<DeliveryMan> GetDeliveryMansByCity(string city)
		{
			IEnumerable<DeliveryMan> myDeliveryMan = new List<DeliveryMan>();
			myDeliveryMan = Get_all_DeliveryMans();
			var thisCity = from ad in myDeliveryMan
						   let myCity = ad.Address.City
						   where myCity.Equals(city)
						   select ad;
			return thisCity;
		}
		//The function return list of deliveries by parameters of city and date
		public IEnumerable<Delivery> GetDeliveryByCityAndDate(string city, DateTime date)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisCityDate = from ad in myDeliveries
							   let myCity = ad.MyAdult.Address.City
							   let myDate = ad.Date
							   where myCity.Equals(city) && myDate.Equals(date)
							   select ad;
			return thisCityDate;
		}
		//The function adds a delivery man to the database
		public void Add_DeliveryMan(DeliveryMan dm)
		{
			new DAL_IMP().Add_DeliveryMan(dm);
		}
		
		//The function adds a delivery to the database
		public void Add_Delivery(Delivery delivery)
		{
			new DAL_IMP().Add_Delivery(delivery);
		}


		//The function return list of deliveries by parameter of delivery man id and date
		public IEnumerable<Delivery> SearchDelivermanID(string idDeliver, DateTime date)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisID_Date = from del in myDeliveries
							   let myId = del.MyDeliveryMan.Id
							   let myDate = del.Date
							   where myId.Equals(idDeliver) && myDate.Equals(date)
							   select del;
			return thisID_Date;

		}

		//The function return a manager that is suitable to the parameters os userNmae and password 
		public Manager LogIn(string userName, string userPassword)
		{
			try
			{
				IEnumerable<Manager> myManagers = new List<Manager>();
				myManagers = Get_all_Managers();
				var thisManager = from del in myManagers
								  let myUserName = del.UserName
								  let myPassword = del.Password
								  where myUserName.Equals(userName) && myPassword.Equals(userPassword)
								  select del;
				return thisManager.ToList()[0];
			}
			catch
			{
				return null;
			}

		}
		// The function return all the managers
		public IEnumerable<Manager> Get_all_Managers()
		{
			return new DAL_IMP().Get_all_Managers();
		}

		//The function return list of delivery men by parameter of name
		public IEnumerable<DeliveryMan> SearchDeliverManByName(string name)
		{

			IEnumerable<DeliveryMan> myDeliveryMan = new List<DeliveryMan>();
			myDeliveryMan = Get_all_DeliveryMans();
			var thisName = from ad in myDeliveryMan
						   let myName = ad.FirstName
						   where myName.Equals(name)
						   select ad;
			return thisName;
		}
		
		//The function return list of delivery men by parameter of id
		public IEnumerable<DeliveryMan> SearchDeliverManById(string id)
		{
			IEnumerable<DeliveryMan> myDeliveryMan = new List<DeliveryMan>();
			myDeliveryMan = Get_all_DeliveryMans();
			var thisId = from ad in myDeliveryMan
						   let myId = ad.Id
						   where myId.Equals(id)
						   select ad;
			return thisId;
		}

		//The function return list of deliveries by parameter of date
		public List<Delivery> SearchByDateTime(DateTime selectedDate)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisDate = from ad in myDeliveries
							   let myDate = ad.Date
							   where myDate.Equals(selectedDate)
							   select ad;
			return thisDate.ToList();
		}

		//The function return list of deliveries by parameter of city
		public List<Delivery> SearchByCity(string city)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisCity = from ad in myDeliveries
							   let myCity = ad.MyAdult.Address.City   
							   where myCity.Equals(city) 
							   select ad;
			return thisCity.ToList();
		}

		//The function return list of deliveries that were delivered successfully by parameter of city and date
		public IEnumerable<Delivery> GetDeliveryByCityAndDateDone(string city, DateTime date)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisCityDate = from ad in myDeliveries
							   let myCity = ad.MyAdult.Address.City
							   let myDate = ad.Date
							   where myCity.Equals(city) && myDate.Equals(date) &&ad.IsDone
							   select ad;
			return thisCityDate;
		}
		//The function return list of deliveries that were delivered yet by parameter of city and date
		public IEnumerable<Delivery> GetDeliveryByCityAndDateUnDone(string city, DateTime date)
		{
			IEnumerable<Delivery> myDeliveries = new List<Delivery>();
			myDeliveries = Get_all_Deliveries();
			var thisCityDate = from ad in myDeliveries
							   let myCity = ad.MyAdult.Address.City
							   let myDate = ad.Date
							   where myCity.Equals(city) && myDate.Equals(date) &&(!ad.IsDone)
							   select ad;
			return thisCityDate;
		}

		//The function return list of cities
		public List<string> GetCities()
		{
			return new DAL_IMP().GetCities();
		}
		//The function return list of streets group by city
		public List<IGrouping<string, string>> GetstreetsGroupedByCity()
		{
			return new DAL_IMP().GetstreetsGroupedByCity();
		}
	}
}

