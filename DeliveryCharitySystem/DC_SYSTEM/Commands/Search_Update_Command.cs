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
	public class Search_Update_Command : ICommand
	{
			private Search_ViewModel search_ViewModel;

			public Search_Update_Command(Search_ViewModel search_ViewModel)
			{
				this.search_ViewModel = search_ViewModel;
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
				return true;
			}
			return false;
		}
			public void Execute(object parameter)
			{
			if ((parameter as string) == "Adult")
				this.search_ViewModel.UpdateAdult();
			if ((parameter as string) == "DeliverMan")
				this.search_ViewModel.Update();
		}

	}
}
