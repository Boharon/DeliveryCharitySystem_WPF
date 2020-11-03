using DC_SYSTEM._BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

using System.Data.Entity;
using RestSharp.Extensions;
using System.Xml.Linq;
using System.Windows;

namespace DC_SYSTEM.DAL
{
	public class DAL_IMP
	{
		
		//The function returns a list of all adult from the data base
		public List<Adult> Get_all_Adults()
		{
			List<Adult> result = new List<Adult>();
			using (var context = new DeliveryContext())
			{
				try
				{
					result = context.Adults.Include(a => a.Address).ToList<Adult>();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }


			}
			return result;
		}
		//The function returns a list of all delivery men from the data base
		public IEnumerable<DeliveryMan> Get_all_DeliveryMans()
		{
			List<DeliveryMan> result = new List<DeliveryMan>();
			using (var context = new DeliveryContext())
			{
				try {
					result = context.DeliveryMans.Include(a => a.Address).ToList<DeliveryMan>();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }
			}
		
			return result;
		}
		

		//The function receives a delivery and defines it as "Done"
		public void IsTaskDone(List<Delivery> deliveries)
		{
			using (var context = new DeliveryContext())
			{
				try { 
				foreach (var delivery in deliveries)
				{
					var old = context.Deliveries.Find(delivery.Code);
					old.IsDone = delivery.IsDone;
				}	
				context.SaveChanges();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }

			}
		}


		//The function returns a list of all deliveries from the data base
		public IEnumerable<Delivery> Get_all_Deliveries()
		{
			List<Delivery> result = new List<Delivery>();
			using (var context = new DeliveryContext())
			{
				try { 
				result = context.Deliveries.Include(a=>a.MyAdult).Include(c => c.MyAdult.Address).Include(b=>b.MyDeliveryMan).Include(d => d.MyDeliveryMan.Address).ToList<Delivery>();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }

			}
			return result;
		}
		//The function returns a list of all addresses from the data base
		public IEnumerable<Address> Get_all_Address()
		{
			List<Address> result = new List<Address>();
			using (var context = new DeliveryContext())
			{
				try
				{
					result = context.Addresses.ToList<Address>();
				}  
				catch { MessageBox.Show("Unable to connect to DataBase"); }

		}
			return result;
		}

		//The function adds an adult to the data base or updates it in case that the adult is already exist
		public void Add_Adult(Adult adult)
		{
			using (var ctx = new DeliveryContext())
			{
				try
				{
					if (ctx.Adults.Find(adult.Id) != null)
					{
						var old = ctx.Adults.Find(adult.Id);
						updateAddress(adult.Address);
						old.FirstName = adult.FirstName;
						old.LastName = adult.LastName;
						old.PhoneNumber = adult.PhoneNumber;
						old.Medicine = adult.Medicine;
						old.Food = adult.Food;
						ctx.SaveChanges();

					}
					else
					{
						ctx.Addresses.Add(adult.Address);
						ctx.Adults.Add(adult);
						ctx.SaveChanges();
					}
				}   
				catch { MessageBox.Show("Unable to connect to DataBase"); }


		}

	}



		//The function adds a delivery to the data base or updates it in case that the delivery is already exist

		public void Add_Delivery(Delivery delivery)
		{
			using (var ctx = new DeliveryContext())
			{
				try { 
				
				var deliveryMan = ctx.DeliveryMans.Find(delivery.MyDeliveryMan.Id);
				var adult = ctx.Adults.Find(delivery.MyAdult.Id);
				delivery.MyAdult = null;
				delivery.MyDeliveryMan = null;
				ctx.Deliveries.Add(delivery);
				ctx.SaveChanges();
				
				var deliveryToUpdate = ctx.Deliveries.Find(delivery.Code);
				deliveryToUpdate.MyAdult = adult;
				deliveryToUpdate.MyDeliveryMan = deliveryMan;
				ctx.SaveChanges();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }

			}

		}
		//The function adds a delivery man to the data base or updates it in case that the delivery man is already exist

		public void Add_DeliveryMan(DeliveryMan dm)
		{
			using (var ctx = new DeliveryContext())
			{
				try { 
				if (ctx.DeliveryMans.Find(dm.Id) != null)
				{
					var old = ctx.DeliveryMans.Find(dm.Id);
					updateAddress(dm.Address);
					old.FirstName = dm.FirstName;
					old.LastName = dm.LastName;
					old.PhoneNumber = dm.PhoneNumber;
					old.Email = dm.Email;
					ctx.SaveChanges();

				}
				else
				{
					ctx.Addresses.Add(dm.Address);
					ctx.DeliveryMans.Add(dm);
					ctx.SaveChanges();
				}
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }

			}

		}

		//The function update an address by another parameter of address
		private void updateAddress(Address address)
		{
			using (var ctx = new DeliveryContext())
				try
				{
					if (ctx.Addresses.Find(address.AddressID) != null)
					{
						var old = ctx.Addresses.Find(address.AddressID);

						old.Street = address.Street;
						old.BuildingNumber = address.BuildingNumber;
						old.City = address.City;

						ctx.SaveChanges();


					}
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }



		}
		//The function returns all the managers from the data base

		public IEnumerable<Manager> Get_all_Managers()
		{

			List<Manager> result = new List<Manager>();
			using (var context = new DeliveryContext())
			{
				try { 
				result = context.Managers.ToList<Manager>();
				}
				catch { MessageBox.Show("Unable to connect to DataBase"); }


			}
			return result;
		}

		//The function returns a list of all cities
		public List<string> GetCities()
		{
			string cityPath = @"..\..\..\Cities and Streets xml\CitiesList.xml";
			XElement citiesRoot = XElement.Load(cityPath);
			return (from item in citiesRoot.Elements() select item.Value).ToList();
		}

		///The function returns a list of all streets gruop by cities
		public List<IGrouping<string, string>> GetstreetsGroupedByCity()
		{
			string streetPath = @"..\..\..\Cities and Streets xml\StreetsList.xml";
			XElement streetsRoot = XElement.Load(streetPath);
			return (from item in streetsRoot.Elements() group item.Element("Street").Value by item.Element("City").Value).ToList();

		}
	}
}
