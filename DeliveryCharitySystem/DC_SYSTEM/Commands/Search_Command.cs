using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class Search_Command : ICommand
	{
		private Search_ViewModel search_ViewModel;

		public Search_Command(Search_ViewModel search_ViewModel)
		{
			this.search_ViewModel = search_ViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			if((parameter as string) == "NameByDeliverMan")
				this.search_ViewModel.SearchDeliverManByName();
			if ((parameter as string) == "IdByDeliverMan")
				this.search_ViewModel.SearchDeliverManById();
			if ((parameter as string) == "CityByDeliverMan")
				this.search_ViewModel.SearchDeliverManByCity();
			if ((parameter as string) == "NameByAdult")
				this.search_ViewModel.SearchAdultByName();
			if ((parameter as string) == "IdByAdult")
				this.search_ViewModel.SearchAdultById();
			if ((parameter as string) == "CityByAdult")
				this.search_ViewModel.SearchAdultByCity();
			if ((parameter as string) == "Update")
				this.search_ViewModel.Update();
			if ((parameter as string) == "UpdateAdult")
				this.search_ViewModel.UpdateAdult();
		}
	}
}
