using DC_SYSTEM.ViewModels;
using DC_SYSTEM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace DC_SYSTEM
{
	/// <summary>
	/// Interaction logic for Menu_Win.xaml
	/// </summary>
	public partial class Menu_Win : Window
	{
		public LogIn_AdministratorViewModel logIn_AdministratorViewModel;
		private DispatcherTimer timer;
		private int imageIndex = 2;

		//Constructor
		public Menu_Win()
		{
			logIn_AdministratorViewModel = new LogIn_AdministratorViewModel(this);
			this.DataContext = logIn_AdministratorViewModel;
			InitializeComponent();
			timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
			timer.Tick += Timer_Tick;
			timer.Start();
			startClock();
			
		}

		// Displaying date and hour
		private void startClock()
		{
			DispatcherTimer timerReal = new DispatcherTimer();
			timerReal.Interval = TimeSpan.FromSeconds(1);
			timerReal.Tick += tickEvent;
			timerReal.Start();
		}


		private void tickEvent(object sender, EventArgs e)
		{
			txtBlockTime.Text = DateTime.Now.ToString();
		}

		// Displaying changing pictures 
		private void Timer_Tick(object sender, EventArgs e)
		{
			firstImage.Source = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), "HomePagePic/" + imageIndex + ".jpg"));
			if (++imageIndex == 5)
				imageIndex = 1;
			
		}
		

		private void buttonClose_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void buttonMenuClose_Click(object sender, RoutedEventArgs e)
		{
			buttonOpenMenu.Visibility = Visibility.Visible;
			buttonCloseMenu.Visibility = Visibility.Collapsed;
		}

		public void enterToSystem(string userName)
		{
			connactionPanel.Visibility = Visibility.Hidden;
			Flipper.Visibility = Visibility.Hidden;
		
			buttonOpenMenu.Visibility = Visibility.Visible;
			buttonOpenMenu.IsEnabled = true;
			buttonCloseMenu.Visibility = Visibility.Collapsed;
		}

		public void exitFromSystem()
		{
			MyPasswordBox.Password = null;
			connactionPanel.Visibility = Visibility.Visible;
			Flipper.Visibility = Visibility.Visible;
			buttonOpenMenu.Visibility = Visibility.Visible;
			
			buttonOpenMenu.IsEnabled = false;
			buttonCloseMenu.Visibility = Visibility.Collapsed;
			
		}

		private void buttonOpenMenu_Click(object sender, RoutedEventArgs e)
		{
			buttonOpenMenu.Visibility = Visibility.Collapsed;
			buttonCloseMenu.Visibility = Visibility.Visible;
			UC.Children.Clear();
			UC.Children.Add(SP);

		}
		
		// The function adds the required user control to the main window users 
		public void Add_UC(String userCntrl)
		{
			System.Windows.Controls.UserControl uc = new System.Windows.Controls.UserControl();
			switch (userCntrl)
			{
				case "SearchDeliverMan":
					uc = new SearchDeliverMan_UserCntrl(this.logIn_AdministratorViewModel);
					break;
				case "SearchAdult":
					 uc = new SearchAdult_UserCntrl(this.logIn_AdministratorViewModel);
					break;
				case "AddAdult":
					
					 uc = new AddAdult_userCntrl(this.logIn_AdministratorViewModel);
					break;
				case "AddDeliverMan":
					uc = new Add_DeliverMan_UserCntrl(this.logIn_AdministratorViewModel);
					break;
				case "AddDelivery":
					uc = new deliveryAreas_usctrl(this.logIn_AdministratorViewModel);
					break;
				case "TasksManager":
					uc = new DeliveriesTasksList_UserCntrl(this.logIn_AdministratorViewModel);
					break;
				case "TaskSchedule":
					uc = new PrintDeliveriesDetails(this.logIn_AdministratorViewModel);
					break;
				case "Graphs":
					uc = new Graphs_View();
					break;
				default:
					
					break;
			}
			UC.Children.Clear();
			UC.Children.Add(uc);


		}
		// Returning to original home page view
		public void ShowHomePage()
		{
			UC.Children.Clear();
			UC.Children.Add(SP);
		}
	}
}
