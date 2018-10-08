using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotesApp.ViewModel.Commands
{
    public class BeginEditComand : ICommand
    {
        public NotesVM Vm { get; set; }
        public event EventHandler CanExecuteChanged;

        public BeginEditComand(NotesVM vm)
        {
            Vm = vm ?? throw new ArgumentNullException(nameof(vm));
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Vm.StartEditing();
        }
    }
}
