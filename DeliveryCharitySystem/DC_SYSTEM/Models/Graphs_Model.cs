using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class Graphs_Model
	{
		public List<Delivery> GetDeliveriesByDateDone(string city, DateTime selectedDate)
		{
			return new BL_IMP().GetDeliveryByCityAndDateDone(city, selectedDate).ToList();
		}
		public List<Delivery> GetDeliveriesByDate(string city, DateTime selectedDate)
		{
			return new BL_IMP().GetDeliveryByCityAndDate(city, selectedDate).ToList();
		}

		public List<Delivery> Get_AllDeliveriesDone()
		{
			return new BL_IMP().Get_AllDeliveriesDone();
		}

		public List<Delivery> Get_AllDeliveriesUnDone()
		{
			return new BL_IMP().Get_AllDeliveriesUnDone();
		}
	}
}
