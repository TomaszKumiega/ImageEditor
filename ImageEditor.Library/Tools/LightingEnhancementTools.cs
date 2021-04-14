using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class LightingEnhancementTools : ILightingEnhancementTools
    {
        private IImageConverter Converter { get; }
        private IChangeBrightnessAlgorithm ChangeBrightnessAlgorithm { get; }
        private IContrastStretchingAlgorithm ContrastStretchingAlgorithm { get; }
        private IContrastShrinkingAlgorithm ContrastShrinkingAlgorithm { get; }

        public LightingEnhancementTools(IImageConverter converter, IChangeBrightnessAlgorithm changeBrightnessAlgorithm, 
            IContrastStretchingAlgorithm contrastStretchingAlgorithm, IContrastShrinkingAlgorithm contrastShrinkingAlgorithm)
        {
            Converter = converter;
            ChangeBrightnessAlgorithm = changeBrightnessAlgorithm;
            ContrastStretchingAlgorithm = contrastStretchingAlgorithm;
            ContrastShrinkingAlgorithm = contrastShrinkingAlgorithm;
        }

        public Bitmap ChangeBrightness(Bitmap image, float brightness)
        {
            var scaledBrightness = brightness / 100;
            var hsvImage = Converter.BitmapToHSVImage(image);
            var hsvResult = ChangeBrightnessAlgorithm.ChangeBrightness(hsvImage, scaledBrightness);
            var result = Converter.HSVImageToBitmap(hsvResult);

            return result;
        }

        public Bitmap ChangeContrast(Bitmap image, float contrast)
        {
            Bitmap result = null;

            if(contrast>0)
            {
                float min = contrast / 500;
                float max = 1 - min;

                var hsvImage = Converter.BitmapToHSVImage(image);
                var hsvResult = ContrastStretchingAlgorithm.StretchContrast(hsvImage, min, max);
                result = Converter.HSVImageToBitmap(hsvResult);
            }
            else if(contrast<0)
            {
                contrast = contrast/-1;
                float min = contrast / 500;
                float max = 1 - min;

                var hsvImage = Converter.BitmapToHSVImage(image);
                var hsvResult = ContrastShrinkingAlgorithm.ShrinkContrast(hsvImage, min, max);
                result = Converter.HSVImageToBitmap(hsvResult);
            }

            return result;
        }
    }
}
