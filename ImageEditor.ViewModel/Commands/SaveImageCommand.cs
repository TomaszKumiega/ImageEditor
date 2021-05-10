using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel.Commands
{
    public class SaveImageCommand : ICommand
    {
        private IMenuViewModel ViewModel { get; }
        public event EventHandler CanExecuteChanged;

        public SaveImageCommand(IMenuViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ViewModel.SaveImage();
        }
    }
}
