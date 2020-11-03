using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class DeliveryManModel
	{
		public void Add_DeliveryMan(DeliveryMan dm)
		{
			new BL_IMP().Add_DeliveryMan(dm);

		}
		public List<string> GetCities()
		{
			return new BL_IMP().GetCities();
		}

		public List<IGrouping<string, string>> GetstreetsGroupedByCity()
		{
			return new BL_IMP().GetstreetsGroupedByCity();
		}
	}
}


