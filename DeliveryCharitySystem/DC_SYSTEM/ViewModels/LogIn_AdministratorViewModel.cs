using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace DC_SYSTEM.ViewModels
{
	public class LogIn_AdministratorViewModel : INotifyPropertyChanged
	{
		public LogIn_AdministratorModel LogIn_AdministratorM;
		public Menu_Win LogIn_AdministratorV;
	
		private string userName;
		public string UserName { get { return userName; } set { userName = value; OnPropertyChanged("UserName"); } }

		private string userPassword;
		public string UserPassword { get { return userPassword; } set { userPassword = value; OnPropertyChanged("UserPassword"); } }

		private Manager manager;
		public Manager Manager	{get { return manager; }set { manager = value; OnPropertyChanged("Manager"); }}

		private ImageSource imageSource;
		public ImageSource ImageSource { get { return imageSource; } set { imageSource = value; OnPropertyChanged("ImageSource"); } }

		private LogIn_Command logIn_CMD;
		public LogIn_Command LogIn_CMD { get { return new LogIn_Command(this); } }

		private logOut_Command logOut_CMD;
		public logOut_Command LogOut_CMD { get { return new logOut_Command(this); } }

		private BtnOfMenu_Command btn_CMD;
		public BtnOfMenu_Command Btn_CMD { get { return new BtnOfMenu_Command(this); } }

		
		//Constructor
		public LogIn_AdministratorViewModel(Menu_Win menu_Win)
		{
			LogIn_AdministratorM = new LogIn_AdministratorModel();
			LogIn_AdministratorV = menu_Win;
			Manager = new Manager();
			logIn_CMD = new LogIn_Command(this);
			btn_CMD = new BtnOfMenu_Command(this);
			String mapImageUrl = LogIn_AdministratorM.mapImageUrl();
			var converter = new ImageSourceConverter();
			ImageSource = (ImageSource)converter.ConvertFromString(mapImageUrl);

		}

	
		// Checking validation of logging in 
		public void LogIn(string password)
		{
			Manager= LogIn_AdministratorM.LogIn(UserName, password);
			if (Manager != null)
				enterToSystem();
			
		}

		//Log in of manager
		public void enterToSystem()
		{
			LogIn_AdministratorV.enterToSystem(Manager.UserName);
		}
	
		//Log out of manager
		public void LogOut()
		{
			UserName = null;
			Manager = null;
			LogIn_AdministratorV.exitFromSystem();
		}

		// Return to display the menu
		public void ShowHomePage()
		{
			LogIn_AdministratorV.ShowHomePage();
		}

		//Adding the wanted user control to the controls
		public void OpenUserControl(string v)
		{
			LogIn_AdministratorV.Add_UC(v);
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
