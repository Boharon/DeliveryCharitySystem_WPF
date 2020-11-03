using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM._BE
{
    public class Address 
    {
        private string _street;
        private int _buildingNumber;
        private string _city;
		
		
        public string AddressID { get; set; }
        
        public string Street
        {
            get { return _street; }
            set
            {
                _street = value;
               
            }
        }
        public int BuildingNumber
        {
            get { return _buildingNumber; }
            set
            {
                _buildingNumber = value;
               
            }
        }
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
              
            }
        }

       // Constructors
        public Address(string _street, int _building_number, string _city)
        {
            AddressID = DateTime.Now.Ticks.ToString("X");
            Street = _street;
            BuildingNumber = _building_number;
            City = _city;
        }

        
        public Address(Address address)
        {
     
            this.AddressID = address.AddressID;
            this.Street = address.Street;
            this.BuildingNumber = address.BuildingNumber;
            this.City = address.City;
        }
        public Address()
        {
            AddressID = DateTime.Now.Ticks.ToString("X");
           
        }

		//Return a stirng of street number and city
		public override string ToString() { return Street + " " + BuildingNumber + ", " + City; }
    }

}
