using DC_SYSTEM.ViewModels;
using LiveCharts;
using LiveCharts.Wpf;
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
	/// Interaction logic for Graphs_View.xaml
	/// </summary>
	public partial class Graphs_View : UserControl
	{
		public Graphs_ViewModel Graphs_VM;
		
		//Constructor
		public Graphs_View()
		{
			Graphs_VM = new Graphs_ViewModel();
			this.DataContext = Graphs_VM;
			InitializeComponent();
			
		}

		// The function shows details of each slice of the pie chart by moving the mouse on 
		private void Chart_OnDataClick(object sender, ChartPoint chartpoint)
		{
			var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

			//clear selected slice.
			foreach (PieSeries series in chart.Series)
				series.PushOut = 0;

			var selectedSeries = (PieSeries)chartpoint.SeriesView;
			selectedSeries.PushOut = 8;
		}


		// Combo box visibility issues
		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

			if (option.SelectedIndex == 0)
			{
				combCity.Visibility = Visibility.Collapsed;
				FutureDatePicker.Visibility = Visibility.Collapsed;
				cmbDWM.Visibility = Visibility.Collapsed;
				PieChart.Visibility = Visibility.Visible;
				CartesianChart.Visibility = Visibility.Collapsed;
				
			}
			if (option.SelectedIndex == 1)
			{
				PieChart.Visibility = Visibility.Collapsed;
				CartesianChart.Visibility = Visibility.Visible;
				combCity.Visibility = Visibility.Visible;
				FutureDatePicker.Visibility = Visibility.Visible;
				cmbDWM.Visibility= Visibility.Visible;
				
			

			}
		}
	}
}




    

 

