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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DC_SYSTEM.Views
{
	/// <summary>
	/// Interaction logic for Add_DeliverMan_UserCntrl.xaml
	/// </summary>
	public partial class Add_DeliverMan_UserCntrl : UserControl
	{
        public DeliveryManViewModel deliveyMan_MV;

        //Constructors
		public Add_DeliverMan_UserCntrl(DeliveryMan deliveryMan, LogIn_AdministratorViewModel logIn_AdministratorVM)
		{
			deliveyMan_MV = new DeliveryManViewModel(deliveryMan, logIn_AdministratorVM);
			this.DataContext = deliveyMan_MV;

			InitializeComponent();
			CmbBx_City.ItemsSource = deliveyMan_MV.cities;
			CmbBx_Street.IsEnabled = false;

		}
		public Add_DeliverMan_UserCntrl(DeliveryMan deliveryMan)
        {
            deliveyMan_MV = new DeliveryManViewModel(deliveryMan);
            this.DataContext = deliveyMan_MV;

            InitializeComponent();
            CmbBx_City.ItemsSource = deliveyMan_MV.cities;
            CmbBx_Street.IsEnabled = false;

        }
        public Add_DeliverMan_UserCntrl()
        {
            deliveyMan_MV = new DeliveryManViewModel();
            this.DataContext = deliveyMan_MV;

            InitializeComponent();
            CmbBx_City.ItemsSource = deliveyMan_MV.cities;
            CmbBx_Street.IsEnabled = false;

        }
        public Add_DeliverMan_UserCntrl(LogIn_AdministratorViewModel logIn_AdministratorVM)
        {
            deliveyMan_MV = new DeliveryManViewModel(logIn_AdministratorVM);
            this.DataContext = deliveyMan_MV;

            InitializeComponent();
            CmbBx_City.ItemsSource = deliveyMan_MV.cities;
            CmbBx_Street.IsEnabled = false;

        }

        //Filling address details by selection
        private void CmbBx_City_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            if (CmbBx_City.SelectedItem != null)
            {
                CmbBx_Street.IsEnabled = true;
                CmbBx_Street.ItemsSource = deliveyMan_MV.streetsGroupedByCity.Find(x => x.Key == (string)CmbBx_City.SelectedItem);
            }

        }

		
	}
}



 
   
  