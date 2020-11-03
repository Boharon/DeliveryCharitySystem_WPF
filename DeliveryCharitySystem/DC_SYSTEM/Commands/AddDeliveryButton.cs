using DC_SYSTEM._BE;
using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class AddDeliveryButton : ICommand
	{
		public DeliveryViewModel DeliveryViewModel
		{
			get { return deliveryViewModel; } set { deliveryViewModel = value; }
		}
		private DeliveryViewModel deliveryViewModel;

		public AddDeliveryButton(DeliveryViewModel deliveryViewModel)
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
			if ((parameter as string) == "Remove")
				this.DeliveryViewModel.RemoveButtonClick();
			if ((parameter as string) == "Add")
				this.DeliveryViewModel.AddButtonClick();
			if ((parameter as string) == "RemoveDeliveryMan")
				this.DeliveryViewModel.RemoveDeliveryManButtonClick();
			if ((parameter as string) == "AddDeliveryMan")
				this.DeliveryViewModel.AddDeliveryManButtonClick();
			if ((parameter as string) == "DO_Delivery")
				this.DeliveryViewModel.DivisionIntoClusters();

		}
	}
}




