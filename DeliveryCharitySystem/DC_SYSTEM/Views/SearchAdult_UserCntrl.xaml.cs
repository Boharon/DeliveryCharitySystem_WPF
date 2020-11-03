using DC_SYSTEM._BE;
using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DC_SYSTEM.Views
{
	/// <summary>
	/// Interaction logic for Search_UserCntrl.xaml
	/// </summary>
	public partial class SearchAdult_UserCntrl : System.Windows.Controls.UserControl
	{
		public Search_ViewModel searchMV;


		//Constructor
		public SearchAdult_UserCntrl(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			searchMV = new Search_ViewModel(this,logIn_AdministratorViewModel);
			this.DataContext = searchMV;
			InitializeComponent();
		}
		
		// Adding user control to the main window
		public void addUC(Adult adult, LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			AddAdult_userCntrl _UserCntrl = new AddAdult_userCntrl(adult,logIn_AdministratorViewModel);
			_UserCntrl.CmbBx_Street.IsEnabled = true;
			myStackPanel.Children.Add(_UserCntrl);

		}
	}
}






	
	
	

