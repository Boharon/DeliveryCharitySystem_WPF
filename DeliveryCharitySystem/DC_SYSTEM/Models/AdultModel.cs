using DC_SYSTEM._BE;
using DC_SYSTEM.BLL;
using DC_SYSTEM.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;

namespace DC_SYSTEM.Models
{
	public class AdultModel
	{
		public void Add_Adult(Adult adult)
		{
			new BL_IMP().Add_Adult(adult);
			
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
