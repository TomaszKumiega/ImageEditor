using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class ChangeToNegativeCommand : ICommand
    {
        private IEffectsToolsViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public ChangeToNegativeCommand(IEffectsToolsViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.ChangeToNegative();
        }
    }
}
