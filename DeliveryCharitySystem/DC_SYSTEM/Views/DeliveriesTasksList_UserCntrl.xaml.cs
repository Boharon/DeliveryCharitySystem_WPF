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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DC_SYSTEM.Views
{
	/// <summary>
	/// Interaction logic for DeliveriesTasksList_UserCntrl.xaml
	/// </summary>
	public partial class DeliveriesTasksList_UserCntrl : UserControl
	{

		public DeliveriesTasks_ViewModel DeliveriesTasks_MV;

		//Constructor
		public DeliveriesTasksList_UserCntrl(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
		{
			DeliveriesTasks_MV = new DeliveriesTasks_ViewModel(logIn_AdministratorViewModel);
			this.DataContext = DeliveriesTasks_MV;
			InitializeComponent();
		}
	}
}
