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

        public ChangeToGrayscaleCommand GetChangeToGrayScaleCommand(IEffectsToolsViewModel viewModel)
        {
            return new ChangeToGrayscaleCommand(viewModel);
        }

        public ChangeToNegativeCommand GetChangeToNegativeCommand(IEffectsToolsViewModel viewModel)
        {
            return new ChangeToNegativeCommand(viewModel);
        }

        public WhiteBalanceCommand GetWhiteBalanceCommand(IColorEnhancementToolsViewModel viewModel)
        {
            return new WhiteBalanceCommand(viewModel);
        }
    }
}
