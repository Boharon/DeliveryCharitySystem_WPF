using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class LogIn_Command:ICommand
	{
		public LogIn_Command(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			LogIn_AdministratorViewModel = logIn_AdministratorViewModel;
		}

		public LogIn_AdministratorViewModel LogIn_AdministratorViewModel { get; }

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			var passwordBox = parameter as PasswordBox;
			var password = passwordBox.Password;
			LogIn_AdministratorViewModel.LogIn(password);
		}
	}
}
