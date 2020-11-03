using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class Search_DelivermanID_Command:ICommand
	{
		private Print_PDF_ViewModel print_PDF_ViewModel;

		public Search_DelivermanID_Command(Print_PDF_ViewModel print_PDF_ViewModel)
		{
			this.print_PDF_ViewModel = print_PDF_ViewModel;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			print_PDF_ViewModel.SearchDelivermanID();
		}
	}
}
