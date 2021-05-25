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

        public ResetChangesCommand GetResetChangesCommand(IMenuViewModel viewModel)
        {
            return new ResetChangesCommand(viewModel);
        }

        public ChangeToGrayScaleCommand GetChangeToGrayScaleCommand(IEffectsToolsViewModel viewModel)
        {
            return new ChangeToGrayScaleCommand(viewModel);
        }

        public ChangeToNegativeCommand GetChangeToNegativeCommand(IEffectsToolsViewModel viewModel)
        {
            return new ChangeToNegativeCommand(viewModel);
        }
    }
}
