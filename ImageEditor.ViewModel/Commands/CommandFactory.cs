using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public SaveImageCommand GetSaveImageCommand(IMenuViewModel viewModel)
        {
            return new SaveImageCommand(viewModel);
        }
    }
}
