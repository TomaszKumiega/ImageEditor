using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class WhiteBalanceCommand : ICommand
    {
        private IColorEnhancementToolsViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public WhiteBalanceCommand(IColorEnhancementToolsViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.WhiteBalance();
        }
    }
}
