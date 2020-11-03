using DC_SYSTEM._BE;
using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class CityActionCommand : ICommand
	{
		public DeliveryViewModel DeliveryViewModel
		{
			get; set;
		}
		private DeliveryViewModel deliveryViewModel;

		public CityActionCommand(DeliveryViewModel deliveryViewModel)
		{
			this.deliveryViewModel = deliveryViewModel;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return true;
			
		
	    }

		public void Execute(object parameter)
		{
			this.deliveryViewModel.upDateByCityList();
		}
	}
}




