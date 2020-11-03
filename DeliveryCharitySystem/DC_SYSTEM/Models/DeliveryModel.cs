using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.Models
{
	public class DeliveryModel
	{

		public void Add_Delivery(Delivery delivery)
		{
			new BL_IMP().Add_Delivery(delivery);

		}

		public  List<Adult> GetAdultsByCity(string city)
		{
			return new BL_IMP().GetAdultsByCity(city).ToList();
		}

		public List<DeliveryMan> GetDeliveryMansByCity(string city)
		{
			return new BL_IMP().GetDeliveryMansByCity(city).ToList();
		}
		public List<DeliveryMan> Get_All_DeliveryMans()
		{
			return new BL_IMP().Get_all_DeliveryMans().ToList();
		}

		public List<Delivery>[] DivisionIntoClusters(List<Adult> selectedAdultsList, List<DeliveryMan> selectedDeliveryMansList, int k, DateTime selectedDate)
		{
			Delivery[] deliveries;
			List<Delivery>[] grupByDeliveryMen = new List<Delivery>[k];
			deliveries= new DivisionIntoClusters().DivisionToClusters(selectedAdultsList, selectedDeliveryMansList, k, selectedDate);
			for (int i = 0; i < k; i++)
				grupByDeliveryMen[i] = new DivisionIntoClusters().DivisionToDelivery(deliveries, i);
			return grupByDeliveryMen;
		}
		public string mapImageUrl(String city,DateTime date)
		{
			List<Delivery> deliveries = new BL_IMP().GetDeliveryByCityAndDate(city, date).ToList();
			return new MapImage().DownloadMap(deliveries);
		}
	}
}
