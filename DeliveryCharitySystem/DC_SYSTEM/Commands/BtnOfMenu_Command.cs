using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class BtnOfMenu_Command : ICommand
	{
		public LogIn_AdministratorViewModel logInVM { get; set; }
		public BtnOfMenu_Command(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			this.logInVM = logIn_AdministratorViewModel;
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
			this.logInVM.OpenUserControl(parameter as string);

		}
	}
}
