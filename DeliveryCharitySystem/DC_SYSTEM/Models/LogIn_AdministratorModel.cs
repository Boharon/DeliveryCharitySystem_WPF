using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class LogIn_AdministratorModel
	{

		public Manager LogIn(string userName, string userPassword)
		{
			return new BL_IMP().LogIn(userName, userPassword);
		}

		public string mapImageUrl()
		{
			List<Delivery> deliveries = new BL_IMP().Get_all_Deliveries().ToList();
			return new MapImage().DownloadHomePageMap(deliveries);

		}
	}
}
