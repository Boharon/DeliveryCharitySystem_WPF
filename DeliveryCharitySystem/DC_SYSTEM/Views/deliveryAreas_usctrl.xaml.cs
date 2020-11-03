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
    /// Interaction logic for deliveryAreas_usctrl.xaml
    /// </summary>
    public partial class deliveryAreas_usctrl : UserControl
    {
        public DeliveryViewModel deliveryMV;

        //Constructors
         public deliveryAreas_usctrl()
        {
            deliveryMV = new DeliveryViewModel();
           
            this.DataContext = deliveryMV;
           
            InitializeComponent();
         
        }
        public deliveryAreas_usctrl(LogIn_AdministratorViewModel logIn_AdministratorViewModel)
        {
            deliveryMV = new DeliveryViewModel(logIn_AdministratorViewModel);

            this.DataContext = deliveryMV;

            InitializeComponent();
           
        }


	}
}
