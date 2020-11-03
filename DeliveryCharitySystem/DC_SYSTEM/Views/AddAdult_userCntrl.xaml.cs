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
    /// Interaction logic for addingOld_usctrl.xaml
    /// </summary>
    public partial class AddAdult_userCntrl : UserControl
    {
        public AdultViewModel adultMV;
        public Adult Adult { get; }
        
        //Constructors
        public AddAdult_userCntrl()
        {
           
            adultMV = new AdultViewModel();
            this.DataContext = adultMV;
         
            InitializeComponent();
            CmbBx_City.ItemsSource = adultMV.cities;
            CmbBx_Street.IsEnabled = false;

        }
        public AddAdult_userCntrl(LogIn_AdministratorViewModel logIn_AdministratorVM)
        {

            adultMV = new AdultViewModel(logIn_AdministratorVM);
            this.DataContext = adultMV;

            InitializeComponent();
            CmbBx_City.ItemsSource = adultMV.cities;
            CmbBx_Street.IsEnabled = false;

        }

		public AddAdult_userCntrl(Adult adult, LogIn_AdministratorViewModel logIn_AdministratorVM)
		{
            adultMV = new AdultViewModel(adult, logIn_AdministratorVM);
            this.DataContext = adultMV;

            InitializeComponent();
            CmbBx_City.ItemsSource = adultMV.cities;
            CmbBx_Street.IsEnabled = false;

        }


        //Filling address details by selection
        private void CmbBx_City_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            if (CmbBx_City.SelectedItem != null)
            {
                CmbBx_Street.IsEnabled = true;
                CmbBx_Street.ItemsSource = adultMV.streetsGroupedByCity.Find(x => x.Key == (string)CmbBx_City.SelectedItem);
            }

        }
	}
}
