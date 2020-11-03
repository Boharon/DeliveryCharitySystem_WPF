using DC_SYSTEM._BE;
using DC_SYSTEM.Commands;
using DC_SYSTEM.Models;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DC_SYSTEM.ViewModels
{
	public class Graphs_ViewModel : INotifyPropertyChanged
	{

		public Graphs_Model graphs_M;
		
		//Of Pie chart
		public List<Delivery> Deliveries_Done_Pie;
		public List<Delivery> Deliveries_UnDone_Pie;
		// Of Bar chart
		public List<Delivery> Deliveries_Done;
		public List<Delivery> Deliveries;

		private SeriesCollection seriesCollection;
		public SeriesCollection SeriesCollection { get { return seriesCollection; } set { seriesCollection = value; OnPropertyChanged("SeriesCollection"); } }

		private List<string> labels;
		public List<string> Labels { get { return labels; } set { labels = value; OnPropertyChanged("Labels"); } }

		public Func<double, string> formatter;
		public Func<double, string> Formatter { get { return formatter; } set { formatter = value; OnPropertyChanged("Formatter"); } }
		
		private string city;
		public string City{get { return city; }set { city = value; OnPropertyChanged("City"); } }

		private DateTime selectedDate;
		public DateTime SelectedDate{get { return selectedDate; }set{	selectedDate = value; OnPropertyChanged("SelectedDate");}}
		
		
		public int choice;
		public int Choice { get { return choice; } set { choice = value; OnPropertyChanged("Choice"); } }
		
		public Graphs_Command graphs_CMD;
		public Graphs_Command Graphs_CMD { get { return new Graphs_Command(this); } }

	    public Func<ChartPoint, string> PointLabel { get; set; }
		
		private List<string> titel;
		public List<string> Titel { get { return titel; } set { titel = value; OnPropertyChanged("Titel"); } }
		
		private ChartValues<double> values;
		public ChartValues<double> Values { get { return values; } set { values = value; OnPropertyChanged("Values"); } }
		
		private SeriesCollection seriesCollectionPie;
		public SeriesCollection SeriesCollectionPie { get { return seriesCollectionPie; } set { seriesCollectionPie = value; OnPropertyChanged("SeriesCollectionPie"); } }
		
		private ChartValues<double> count_Done_Pie;
		public ChartValues<double> Count_Done_Pie { get { return count_Done_Pie; } set { count_Done_Pie = value; OnPropertyChanged("Count_Done_Pie"); } }
		
		private ChartValues<double> count_UnDone_Pie;
		public ChartValues<double> Count_UnDone_Pie { get { return count_UnDone_Pie; } set { count_UnDone_Pie = value; OnPropertyChanged("Count_UnDone_Pie"); } }
		
		public int prisaOption;
		public int PrisaOption { get { return prisaOption; } set { prisaOption = value; OnPropertyChanged("PrisaOption"); } }
		
		//Constructors
		public Graphs_ViewModel()
		{
			graphs_M = new Graphs_Model();
			Deliveries_Done = new List<Delivery>();
			Deliveries = new List<Delivery>();
			Formatter = value => value.ToString("N");
			graphs_CMD = new Graphs_Command(this);
			SelectedDate = DateTime.Now;
			Labels = new List<string>();
			PointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);
			Values = new ChartValues<double>();
			Deliveries_Done_Pie = new List<Delivery>();
			Deliveries_UnDone_Pie = new List<Delivery>();
			Count_Done_Pie = new ChartValues<double>();
			Count_UnDone_Pie = new ChartValues<double>();
			PrisaOption = -1;
			Choice = -1;


		}
		public void GetDeliveriesByDate(DateTime date)
		{
			Deliveries_Done = graphs_M.GetDeliveriesByDateDone(City, date);
			Deliveries = graphs_M.GetDeliveriesByDate(City, date);
		}
		
		public void Get_AllDeliveriesDone()
		{
			Deliveries_Done_Pie = graphs_M.Get_AllDeliveriesDone();
			Count_Done_Pie = new ChartValues<double>();
			Count_Done_Pie.Add(Deliveries_Done_Pie.Count);

		}
		public void Get_AllDeliveriesUndone()
		{
			Deliveries_UnDone_Pie = graphs_M.Get_AllDeliveriesUnDone();
			Count_UnDone_Pie = new ChartValues<double>();
			Count_UnDone_Pie.Add(Deliveries_UnDone_Pie.Count);
		}

		// Draw the graph , the pie chart or the bar chart by selection
		public void DisplayGraph()
		{
			if (prisaOption == 0)
				MakeGraphsPie();
			if (prisaOption == 1)
				MakeGraphs();

		}
		
		//Draw Bar Chart 
		public void MakeGraphs()
		{
			SeriesCollection = new SeriesCollection
				{
					new ColumnSeries
					{
						Title = "תכנון",
						Fill=Brushes.HotPink,
						Values = new ChartValues<double>()
					}
				 };
			SeriesCollection.Add(new ColumnSeries
			{
				Title = "ביצוע",
				Fill =Brushes.Yellow,
				Values = new ChartValues<double>()
			}) ;


			switch (Choice)
			{
				// Daily choice
				case 0:

					{
						DateTime date;
						Labels = new List<string> { selectedDate.ToShortDateString() };
						date = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day);
						GetDeliveriesByDate(date);
						SeriesCollection[0].Values.Add((double)Deliveries.Count);
						SeriesCollection[1].Values.Add((double)Deliveries_Done.Count);
					}
					break;

				// Weekly choice
				case 1:
					{
						DateTime date;
						Labels = new List<string>();
						for (int i = 7; i >= 0; i--)
						{

							date = selectedDate.AddDays(-i);
							Labels.Add(date.ToShortDateString());
							GetDeliveriesByDate(date);
							SeriesCollection[0].Values.Add((double)Deliveries.Count);
							SeriesCollection[1].Values.Add((double)Deliveries_Done.Count);

						}
						break;
					}
			//Monthly choice 
				case 2:
					{
						int num = 30;
						DateTime date;
						Labels = new List<string>();
						if (selectedDate.Month == 2)
							num = 29;
						for (int i = 1; i <= num; i++)
						{
							Labels.Add(i.ToString());
							date = new DateTime(selectedDate.Year, selectedDate.Month, i);
							GetDeliveriesByDate(date);
							SeriesCollection[0].Values.Add((double)Deliveries.Count);
							SeriesCollection[1].Values.Add((double)Deliveries_Done.Count);

						}
					}

					break;
				default:
					break;
			}
		}

		// Draw graph pie of planning VS doing parameters
		public void MakeGraphsPie()
		{

			Get_AllDeliveriesDone();
			Get_AllDeliveriesUndone();

		}
		//Property changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged
					(this, new PropertyChangedEventArgs(propertyName));


		}

	}
}






