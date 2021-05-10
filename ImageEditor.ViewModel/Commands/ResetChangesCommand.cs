using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class ResetChangesCommand : ICommand
    {
        private IMenuViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public ResetChangesCommand(IMenuViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.Reset();
        }
    }
}
