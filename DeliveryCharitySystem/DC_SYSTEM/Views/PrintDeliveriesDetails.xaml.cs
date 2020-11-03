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
	/// Interaction logic for PrintDeliveriesDetails.xaml
	/// </summary>
	public partial class PrintDeliveriesDetails : UserControl
	{
		public Print_PDF_ViewModel Print_PDF_VM;
		public LogIn_AdministratorViewModel LogIn_AdministratorVM;
		
		//Constructor
		public PrintDeliveriesDetails(LogIn_AdministratorViewModel logIn_AdministratorVM)
		{
			LogIn_AdministratorVM = logIn_AdministratorVM;
			Print_PDF_VM = new Print_PDF_ViewModel();

			this.DataContext = Print_PDF_VM;
			InitializeComponent();
		}


		//Print pdf of deliveries by deliver man
		private void BTN_Display_Click(object sender, RoutedEventArgs e)
		{
			GridForPrinting.Visibility = Visibility;
			PrintDialog printDialod = new PrintDialog();
			if (printDialod.ShowDialog() == true)
			{
				printDialod.PrintVisual(GridForPrinting, "Invoice");
			}
			var result = MessageBox.Show("האם ברצונך לבצע הדפסות נוספת?", "הדפסה", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
			if (result == MessageBoxResult.No)
				LogIn_AdministratorVM.ShowHomePage();

		}
	}
}
