﻿using ImageEditor.Library.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
            PropertyChanged += ChangeContrast;
            ImageProvider.ResetEvent += OnReset;
            _contrast = 0;
            _brightness = 0;
        }

        private void OnReset(object sender, EventArgs args)
        {
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
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeContrast(new Bitmap(ImageProvider.EditedImage), _contrast);
        }

        private void ChangeBrightness(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "Brightness") return;
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeBrightness(new Bitmap(ImageProvider.EditedImage), _brightness);
        }
    }
}
