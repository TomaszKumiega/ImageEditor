﻿using ImageEditor.Library.Tools;
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
            }
        }

        private void ChangeToGrayscale()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToGrayScale(ImageProvider.EditedImage);
        }

        private void ChangeToNegative()
        {
            ImageProvider.EditedImage = EffectsTools.ChangeToNegative(ImageProvider.EditedImage);
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
