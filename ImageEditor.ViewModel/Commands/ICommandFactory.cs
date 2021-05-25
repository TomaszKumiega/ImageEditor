﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel.Commands
{
    public interface ICommandFactory
    {
        SaveImageCommand GetSaveImageCommand(IMenuViewModel viewModel);
        ResetChangesCommand GetResetChangesCommand(IMenuViewModel viewModel);
        ChangeToGrayScaleCommand GetChangeToGrayScaleCommand(IEffectsToolsViewModel viewModel);
        ChangeToNegativeCommand GetChangeToNegativeCommand(IEffectsToolsViewModel viewModel);
    }
}
