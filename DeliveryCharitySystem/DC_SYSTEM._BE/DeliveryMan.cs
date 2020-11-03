using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM._BE
{
   
    public class DeliveryMan : ValidationCheck, IDataErrorInfo
    {
		private string id;
		private string firstName;
		private string lastName;
		private string phoneNumber;
		private string email;
		private Address address;


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
		public string Email
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
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


		//Constructors
		public DeliveryMan(string id, string firstName, string lastName, string phoneNumber, string email,Address address)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
			Address =address;

		}
		public DeliveryMan(DeliveryMan deliveryMan)
		{
			this.Id = deliveryMan.Id;
			this.FirstName = deliveryMan.FirstName;
			this.LastName = deliveryMan.LastName;
			this.PhoneNumber = deliveryMan.PhoneNumber;
			this.Email = deliveryMan.Email;
			this.Address = deliveryMan.Address;
			
		}
		public DeliveryMan()
		{ }
		// Validation Checking of each deatil in delivery man details
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
						if (!String.IsNullOrWhiteSpace(FirstName) && !IsHebrewLetters(FirstName))
							Error = "הנתון שהוזן אינו תקין";
						else { Error = null; }
						break;

					case "LastName":
						if (!String.IsNullOrWhiteSpace(LastName) && !IsHebrewLetters(LastName))
							Error = "הנתון שהוזן אינו תקין";
						else { Error = null; }
						break;

					case "PhoneNumber":
						if (!String.IsNullOrWhiteSpace(PhoneNumber) && !IsPhoneNumber(PhoneNumber))
							Error = "מספר הפלאפון שהוזן אינו תקין";
						else { Error = null; }
						break;
					case "Email":
						if (!String.IsNullOrWhiteSpace(Email) && IsHebrewLetters(Email))
							Error = "כתובת המייל שהוזנה אינה תקינה";
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

					
					default:
						return Error;
				}
				return Error;
			}
		}
		//Final check validation before inserting to data base
		public bool IsValid()
		{
			if ((!String.IsNullOrEmpty(Id) && IsIdentify(Id)) && (!String.IsNullOrWhiteSpace(FirstName) && IsHebrewLetters(FirstName) && (!String.IsNullOrWhiteSpace(LastName) && IsHebrewLetters(LastName))) && (!String.IsNullOrWhiteSpace(PhoneNumber) && IsPhoneNumber(PhoneNumber)) && (! String.IsNullOrWhiteSpace(Address.Street)) &&(! String.IsNullOrWhiteSpace(Address.City)) && (!String.IsNullOrWhiteSpace(Address.BuildingNumber.ToString()) && IsNumbers(Address.BuildingNumber.ToString())) && (!String.IsNullOrWhiteSpace(Email) && (!IsHebrewLetters(Email))))
			{
				
				return true;
			}
			return false;

		}

	}
}
