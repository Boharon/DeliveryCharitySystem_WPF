using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xceed.Wpf.Toolkit;
using static DC_SYSTEM._BE.ValidationCheck;

namespace DC_SYSTEM._BE
{
	public class Adult : ValidationCheck, IDataErrorInfo
	{
		private string id;
		private string firstName;
		private string lastName;
		private string phoneNumber;
		private Address address;
		private bool food;
		private bool medicine;
		private List<Delivery> deliveries;


  //Properties

		[Key]
		public string Id
		{
			get { return id; }
			set
			{
				id = value;
			}
		}
		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;
			}
		}
		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;
			}
		}
		public string PhoneNumber
		{
			get
			{
				return phoneNumber;
			}
			set
			{
				phoneNumber = value;
			}
		}

		public Address Address
		{
			get
			{
				return address;
			}
			set
			{
				address = value;
			}

		}


		public bool Food
		{
			get
			{
				return food;
			}
			set
			{
				food = value;
			}
		}
		public bool Medicine
		{
			get
			{
				return medicine;
			}
			set
			{
				medicine = value;
			}
		}
		public List<Delivery> Deliveries
		{
			get
			{
				return deliveries;
			}
			set
			{
				deliveries = value;
			}
		}


		//Constructors

		public Adult(string id, string firstName, string lastName, string phoneNumber,Address address,  bool food, bool medicine)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Address = address;
			Food = food;
			Medicine = medicine;
			Deliveries = new List<Delivery>();
		}
		public Adult()
		{ }


		public Adult(Adult adult)
		{
			this.Id = adult.id;
			this.FirstName = adult.firstName;
			this.LastName = adult.lastName;
			this.PhoneNumber = adult.phoneNumber;
			this.Address = adult.Address;
			this.Food = adult.food;
			this.Medicine = adult.medicine;

		}
		// Return an Adult string
		public override string ToString() { return Id + " " + FirstName + " " + LastName +" "+ PhoneNumber+ " " + Address.AddressID+ " "; }


		// Validation Checking of each deatil in adult details
		public string Error
		{
			get;
			private set;
		}
		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					
					case "Id":
						if (!String.IsNullOrWhiteSpace(Id) && !IsIdentify(Id))
							Error = "תעודת הזהות שהוזנה אינה תקינה ";
						else { Error = null; }

						break;
					
					case "FirstName":
						if (!String.IsNullOrWhiteSpace(FirstName)&& !IsHebrewLetters(FirstName))
							Error = "הנתון שהוזן אינו תקין";
						else { Error = null; }
						break;

					case "LastName":
						if (!String.IsNullOrWhiteSpace(LastName)&& !IsHebrewLetters(LastName))
							Error = "הנתון שהוזן אינו תקין";
						else { Error = null; }
						break;

					case "PhoneNumber":
						if (!String.IsNullOrWhiteSpace(PhoneNumber) && !IsPhoneNumber(PhoneNumber))
							Error = "מספר הפלאפון שהוזן אינו תקין";
						else { Error = null; }
						break;
					
					case "Street":
						if (String.IsNullOrWhiteSpace(Address.Street))
							Error = "לא נבחר רחוב";
						else { Error = null; }
						break;

					case "City":
						if (String.IsNullOrWhiteSpace(Address.City))
							Error = "לא נבחרה עיר ";
						else { Error = null; }
						break;

					case "Number":
						if (!String.IsNullOrWhiteSpace(Address.BuildingNumber.ToString()) && !IsNumbers(Address.BuildingNumber.ToString()))
							Error = "הנתון שהוזן אינו תקין";
						else { Error = null; }
						break;

					case "Food":
						if (! IsSelectedOption(Food,Medicine))
							Error = "לא נבחרה אופצייה לחלוקה";
						else { Error = null; }
						break;


					case "Medicine":
						if (!IsSelectedOption(Food, Medicine))
							Error = "לא נבחרה אופצייה לחלוקה";
						else { Error = null; }
						break;

					default:
						return Error;
				}
				return Error;
			}
		}

		//Final check validation before inserting to data base
		public bool IsValid()
		{
			if( (!String.IsNullOrEmpty(Id) && IsIdentify(Id)) && (!String.IsNullOrWhiteSpace(FirstName) && IsHebrewLetters(FirstName) && (!String.IsNullOrWhiteSpace(LastName) && IsHebrewLetters(LastName))) && (!String.IsNullOrWhiteSpace(PhoneNumber) && IsPhoneNumber(PhoneNumber)) && (!String.IsNullOrWhiteSpace(Address.Street))&& (!String.IsNullOrWhiteSpace(Address.City))&& (!String.IsNullOrWhiteSpace(Address.BuildingNumber.ToString()) && IsNumbers(Address.BuildingNumber.ToString())&& (IsSelectedOption(Food, Medicine))))
			{
				return true;
			}
			return false;

		}
	}
}
