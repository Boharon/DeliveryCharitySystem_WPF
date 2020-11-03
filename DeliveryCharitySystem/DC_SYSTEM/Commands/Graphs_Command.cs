using DC_SYSTEM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DC_SYSTEM.Commands
{
	public class Graphs_Command : ICommand
	{
		Graphs_ViewModel graphs_VM;

		public Graphs_Command(Graphs_ViewModel graphs_VM)
		{
			this.graphs_VM = graphs_VM;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{

			graphs_VM.DisplayGraph();
		}
	}
}
