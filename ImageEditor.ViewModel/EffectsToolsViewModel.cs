using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Commands;
using ImageEditor.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel
{
    public class EffectsToolsViewModel : IEffectsToolsViewModel
    {
        private float _sharpenStrength;
        private IImageProvider ImageProvider { get; }
        private IEffectsTools EffectsTools { get; }

        public ICommand ChangeToGrayScaleCommand { get; }
        public ICommand ChangeToNegativeCommand { get; }

        public float SharpeningStrength 
        { 
            get => _sharpenStrength; 
            set
            {
                if(value == 0 && _sharpenStrength != 0)
                {
                    RemoveSharpening();
                }
                else if(value!=_sharpenStrength)
                {
                    _sharpenStrength = value;
                    ApplySharpening();
                }
            }
        }

        public EffectsToolsViewModel(ICommandFactory commandFactory, IImageProvider imageProvider, IEffectsTools effectsTools)
        {
            ImageProvider = imageProvider;
            EffectsTools = effectsTools;
            ChangeToGrayScaleCommand = commandFactory.GetChangeToGrayScaleCommand(this);
            ChangeToNegativeCommand = commandFactory.GetChangeToNegativeCommand(this);
            ImageProvider.ApplyEvent += OnApply;
        }

        private void OnApply(object sender, ApplyEventArgs args)
        {
            switch(args.Operation)
            {
                case Operation.Grayscale: ChangeToGrayscale();
                    break;
                case Operation.Negative: ChangeToNegative();
                    break;
                case Operation.Sharpening: Sharpen();
                    break;
            }
        }

        private void RemoveSharpening()
        {
            ImageProvider.RemoveOperation(Operation.Sharpening);
        }

        private void ChangeToGrayscale()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToGrayScale(ImageProvider.EditedImage);
        }

        private void ChangeToNegative()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToNegative(ImageProvider.EditedImage);
        }

        private void Sharpen()
        {
            ImageProvider.EditedImage = EffectsTools.Sharpen(ImageProvider.EditedImage, _sharpenStrength);
        }

        private void ApplySharpening()
        {
            ImageProvider.ApplyOperation(Operation.Sharpening);
        }

        public void ApplyGrayscale()
        {
            ImageProvider.ApplyOperation(Operation.Grayscale);
        }

        public void ApplyNegative()
        {
            ImageProvider.ApplyOperation(Operation.Negative);
        }
    }
}
