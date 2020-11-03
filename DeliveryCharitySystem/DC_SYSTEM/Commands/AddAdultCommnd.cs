using DC_SYSTEM._BE;
using DC_SYSTEM.ViewModels;
using System;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class AddAdultCommnd : ICommand
	{
		public AdultViewModel AdultVM { get; set; }
		public AddAdultCommnd(AdultViewModel myAdultVM)
		{
			this.AdultVM = myAdultVM;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			//return true;
			if (parameter != null)
			{
				var s = parameter as Adult;
				if (s.IsValid())
					return true;
			}
			return false;
		}

		public void Execute(object parameter)
		{
			this.AdultVM.AddAdult();

		}

	}
}