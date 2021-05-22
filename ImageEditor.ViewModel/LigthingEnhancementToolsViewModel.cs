﻿using ImageEditor.Library.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class LigthingEnhancementToolsViewModel : ILightingEnhancementToolsViewModel, INotifyPropertyChanged
    {
        private IImageProvider ImageProvider { get; }
        private ILightingEnhancementTools LightingEnhancementTools { get; }
        private float _contrast;
        private float _brightness;

        public event PropertyChangedEventHandler PropertyChanged;

        public float Contrast 
        { 
            get => _contrast;
            set
            {
                if (value != _contrast)
                {
                    _contrast = value;
                    OnPropertyChanged("Contrast");
                }
            }
        }

        public float Brightness 
        
        {
            get => _brightness; 
            set
            {
                if (value != _brightness)
                {
                    _brightness = value;
                    OnPropertyChanged("Brightness");
                }
            }
        }

        public LigthingEnhancementToolsViewModel(IImageProvider imageProvider, ILightingEnhancementTools lightingEnhancementTools)
        {
            LightingEnhancementTools = lightingEnhancementTools;
            ImageProvider = imageProvider;
            PropertyChanged += ChangeBrightness;
            _contrast = 0;
            _brightness = 0;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ChangeContrast(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "Contrast") return;
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeContrast(ImageProvider.EditedImage, _contrast);
        }

        private async void ChangeBrightness(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "Brightness") return;
            ImageProvider.EditedImage = await LightingEnhancementTools.ChangeBrightness(ImageProvider.OriginalImage, _brightness);
        }
    }
}
