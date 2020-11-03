using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class DeliveriesTasks_Model
	{
		public List<Delivery> SearchByCityAndDateTime(string city, DateTime selectedDate)
		{
			return new BL_IMP().GetDeliveryByCityAndDate(city, selectedDate).ToList();
		}

		public List<Delivery> SearchByDateTime(DateTime selectedDate)
		{
			return new BL_IMP().SearchByDateTime( selectedDate);
		}

		public List<Delivery> SearchByCity(string city)
		{
			return new BL_IMP().SearchByCity(city);
		}

		public void IsTaskDone(List<Delivery> Deliveries)
		{
			new BL_IMP().IsTaskDone(Deliveries);
		}
	}
}
