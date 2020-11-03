using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class DeliveriesTask_Command : ICommand
	{
		public DeliveriesTasks_ViewModel deliveriesTasks;

		public DeliveriesTask_Command(DeliveriesTasks_ViewModel deliveriesTasks_ViewModel)
		{
			this.deliveriesTasks = deliveriesTasks_ViewModel;
		}



		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			deliveriesTasks.SearchByOption();
		}
		
	}
}
