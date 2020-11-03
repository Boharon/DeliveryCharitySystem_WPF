using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DC_SYSTEM.ViewModels
{
	public class Print_PDF_ViewModel : INotifyPropertyChanged
	{
		Print_PDF_Model printModel;
		
		private DateTime selectedDate;
		public DateTime SelectedDate { get { return selectedDate; } set { selectedDate = value; OnPropertyChanged("SelectedDate"); } }
		
		private string idDeliver;
		public string IdDeliver { get { return idDeliver; } set { idDeliver = value; OnPropertyChanged("IdDeliver"); } }
		
		public Search_DelivermanID_Command searchId_CMD;
		public Search_DelivermanID_Command SearchId_CMD { get { return new Search_DelivermanID_Command(this); } }
		
		private List<Delivery> deliveriesBy_ID;
		public List<Delivery> DeliveriesBy_ID { get { return deliveriesBy_ID; } set { deliveriesBy_ID = value; OnPropertyChanged("DeliveriesBy_ID"); } }

		//Constructor
		public Print_PDF_ViewModel()
		{

			printModel = new Print_PDF_Model();
			searchId_CMD = new Search_DelivermanID_Command(this);
			deliveriesBy_ID = new List<Delivery>();
			selectedDate = DateTime.Now;
		}


		public void SearchDelivermanID()
		{
			DeliveriesBy_ID = printModel.SearchDelivermanID(IdDeliver, SelectedDate).ToList();
		
		}

		// Property changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));

		}
	}
}
