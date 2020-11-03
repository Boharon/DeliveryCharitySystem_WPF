using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class Search_Model
	{
		public IEnumerable<DeliveryMan> SearchDeliverManByName(string name)
		{
			return new BL_IMP().SearchDeliverManByName(name);
		}

		public IEnumerable<DeliveryMan> SearchDeliverManById(string id)
		{
			return new BL_IMP().SearchDeliverManById(id);
		}

		public IEnumerable<DeliveryMan> SearchDeliverManByCity(string city)
		{
			return new BL_IMP().GetDeliveryMansByCity(city);
		}
		public IEnumerable<Adult> SearchAdultByName(string name)
		{
			return new BL_IMP().SearchAdultByName(name);
		}

		public IEnumerable<Adult> SearchAdultById(string id)
		{
			return new BL_IMP().SearchAdultById(id);
		}

		public IEnumerable<Adult> SearchAdultByCity(string city)
		{
			return new BL_IMP().SearchAdultByCity(city);
		}
	}
}
