using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class ChangeToGrayScaleCommand : ICommand
    {
        private IEffectsToolsViewModel ViewModel { get; }

        public event EventHandler CanExecuteChanged;

        public ChangeToGrayScaleCommand(IEffectsToolsViewModel viewModel)
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
