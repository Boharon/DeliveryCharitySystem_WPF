using DC_SYSTEM._BE;
using DC_SYSTEM.Models;
using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class AddDeliveryManCommand : ICommand
	{
		public DeliveryManViewModel DeliveryMan_VM { get; set; }

		public AddDeliveryManCommand(DeliveryManViewModel myDeliveryManVM)
		{
			this.DeliveryMan_VM = myDeliveryManVM;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }

		}

		public bool CanExecute(object parameter)
		{
		
			if (parameter != null)
			{
				var s = parameter as DeliveryMan;
				if (s.IsValid())
					return true;
			}
			return false;
		}

		public void Execute(object parameter)
		{
			this.DeliveryMan_VM.AddDeliveryMan();
		}

	}



}




