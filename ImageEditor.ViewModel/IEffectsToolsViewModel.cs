using ImageEditor.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel
{
    public interface IEffectsToolsViewModel
    {
        ICommand ChangeToGrayScaleCommand { get; }
        ICommand ChangeToNegativeCommand { get; }
        void ApplyGrayscale();
        void ApplyNegative();
    }
}
