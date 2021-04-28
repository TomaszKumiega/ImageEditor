using ImageEditor.Library.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class LigthingEnhancementToolsViewModel : ILightingEnhancementToolsViewModel
    {
        private IImageProvider ImageProvider { get; }
        private ILightingEnhancementTools LightingEnhancementTools { get; }
        private float _contrast;
        private float _brightness;

        public float Contrast 
        { 
            get => _contrast; 
            set
            {
                if (value != 0) ChangeContrast(value);
                _contrast = value;
            }
        }

        public float Brightness 
        
        {
            get => _brightness; 
            set
            {
                if (value != 0) ChangeBrightness(value);
                _brightness = value;
            }
        }

        public LigthingEnhancementToolsViewModel(IImageProvider imageProvider, ILightingEnhancementTools lightingEnhancementTools)
        {
            LightingEnhancementTools = lightingEnhancementTools;
            ImageProvider = imageProvider;
            _contrast = 0;
            _brightness = 0;
        }

        private void ChangeContrast(float contrast)
        {
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeContrast(ImageProvider.EditedImage, contrast);
        }

        private void ChangeBrightness(float brightness)
        {
            ImageProvider.EditedImage = LightingEnhancementTools.ChangeBrightness(ImageProvider.EditedImage, brightness);
        }
    }
}
