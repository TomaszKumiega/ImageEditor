using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel
{
    public class EffectsToolsViewModel : IEffectsToolsViewModel
    {
        private IImageProvider ImageProvider { get; }
        private IEffectsTools EffectsTools { get; }

        public ICommand ChangeToGrayScaleCommand { get; }
        public ICommand ChangeToNegativeCommand { get; }

        public EffectsToolsViewModel(ICommandFactory commandFactory, IImageProvider imageProvider, IEffectsTools effectsTools)
        {
            ImageProvider = imageProvider;
            EffectsTools = effectsTools;
            ChangeToGrayScaleCommand = commandFactory.GetChangeToGrayScaleCommand(this);
            ChangeToNegativeCommand = commandFactory.GetChangeToNegativeCommand(this);
        }

        public void ChangeToGrayScale()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToGrayScale(ImageProvider.EditedImage);
        }

        public void ChangeToNegative()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToNegative(ImageProvider.EditedImage);
        }
    }
}
