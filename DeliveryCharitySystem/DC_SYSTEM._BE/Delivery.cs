using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Controls;

namespace DC_SYSTEM._BE
{
    public class Delivery
    {
		//	Properties

		[Key]
		public string Code { get; set; }
		public DateTime Date { get; set; }
		public DeliveryMan MyDeliveryMan { get; set; }
        public Adult MyAdult { get; set; }
		public int AreaGroup { get; set; }
		public bool IsDone { get; set; }


		//Constructors
		public Delivery()
		{
			Code = DateTime.Now.Ticks.ToString("X");
		}

		public Delivery(DateTime date, Adult adult,DeliveryMan deliveryMan, int areaGroup, bool isDone)
		{
			Code = DateTime.Now.Ticks.ToString("X");
			Date = date;
			MyDeliveryMan = deliveryMan;
			this.MyAdult = new Adult(adult);
			AreaGroup = areaGroup;
			IsDone = isDone;
		}
	
	}
}
