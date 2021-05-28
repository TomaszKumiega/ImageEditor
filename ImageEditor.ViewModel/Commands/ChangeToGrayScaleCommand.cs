using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class ChangeToGrayscaleCommand : ICommand
    {
        private IEffectsToolsViewModel ViewModel { get; }

        public event EventHandler CanExecuteChanged;

        public ChangeToGrayscaleCommand(IEffectsToolsViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.ChangeToGrayScale();
        }
    }
}
