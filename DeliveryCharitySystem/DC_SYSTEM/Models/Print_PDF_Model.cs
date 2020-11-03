using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class Print_PDF_Model
	{


		public IEnumerable<Delivery> SearchDelivermanID(string idDeliver ,DateTime date)
		{
			return new BL_IMP().SearchDelivermanID(idDeliver,date);
		}
	}
}


