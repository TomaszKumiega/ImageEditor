using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Events;
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
                if(value == 0 && _contrast != 0)
                {
                    RemoveContrast();
                }
                else if (value != _contrast)
                {
                    _contrast = value;
                    ApplyContrast();
                    OnPropertyChanged("Contrast");
                }
            }
        }

        public float Brightness 
        
        {
            get => _brightness; 
            set
            {
                if(value == 0 && _brightness != 0)
                {
                    RemoveBrightness();
                }
                else if (value != _brightness)
                {
                    _brightness = value;
                    ApplyBrightness();
                    OnPropertyChanged("Brightness");
                }
            }
        }

        public LigthingEnhancementToolsViewModel(IImageProvider imageProvider, ILightingEnhancementTools lightingEnhancementTools)
        {
            LightingEnhancementTools = lightingEnhancementTools;
            ImageProvider = imageProvider;
            ImageProvider.ResetEvent += OnReset;
            ImageProvider.ApplyEvent += OnApply;
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

        private void ApplyContrast()
        {
            ImageProvider.ApplyOperation(Operation.Contrast);
        }

        private void ApplyBrightness()
        {
            ImageProvider.ApplyOperation(Operation.Brightness);
        }

        private void RemoveContrast()
        {
            ImageProvider.RemoveOperation(Operation.Contrast);
        }

        private void RemoveBrightness()
        {
            ImageProvider.RemoveOperation(Operation.Brightness);
        }

        private void OnApply(object sender, ApplyEventArgs args)
        {
            switch (args.Operation)
            {
                case Operation.Contrast:
                    ChangeContrast();
                    break;
                case Operation.Brightness:
                    ChangeBrightness();
                    break;
            }
        }

        private void ChangeContrast()
        {
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeContrast(new Bitmap(ImageProvider.EditedImage), _contrast);
        }

        private void ChangeBrightness()
        {
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeBrightness(new Bitmap(ImageProvider.EditedImage), _brightness);
        }
    }
}
