

using DC_SYSTEM._BE;
using DC_SYSTEM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM
{
	public class Program
	{
		public void peula()
		{
			using (var ctx = new DeliveryContext())
			{
				//var deliver = new Delivery() { Code = 1 };

				//ctx.Deliveries.Add(deliver);
				ctx.SaveChanges();
			}
		}
	}
}
