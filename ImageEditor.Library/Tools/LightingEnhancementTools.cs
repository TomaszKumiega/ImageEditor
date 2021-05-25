using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using ImageEditor.Library.Helpers;
using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class LightingEnhancementTools : ILightingEnhancementTools
    {
        private IImageConverter Converter { get; }
        private IChangeBrightnessAlgorithm ChangeBrightnessAlgorithm { get; }
        private IContrastStretchingAlgorithm ContrastStretchingAlgorithm { get; }

        public LightingEnhancementTools(IImageConverter converter, IChangeBrightnessAlgorithm changeBrightnessAlgorithm, 
            IContrastStretchingAlgorithm contrastStretchingAlgorithm)
        {
            Converter = converter;
            ChangeBrightnessAlgorithm = changeBrightnessAlgorithm;
            ContrastStretchingAlgorithm = contrastStretchingAlgorithm;
        }

        public Bitmap ChangeBrightness(Bitmap image, float brightness)
        {
            var scaledBrightness = (int) (brightness * 2.55);
            var result = ChangeBrightnessAlgorithm.ChangeBrightness(image, scaledBrightness);

            return result;
        }

        public Bitmap ChangeContrast(Bitmap image, float contrast)
        {
            Bitmap result = null;

            if(contrast>0)
            {
                var hsvImage = Converter.BitmapToHSVImage(image);

                float actualMin = 0-(contrast/400);
                float actualMax = 1+(contrast/400);

                var hsvResult = ContrastStretchingAlgorithm.StretchContrast(hsvImage, actualMin, actualMax);

                result = Converter.HSVImageToBitmap(hsvResult);
            }
            else if(contrast<0)
            {
                contrast *= -1;

                var min = 0 + (contrast / 400);
                var max = 1 - (contrast / 400);
                var hsvImage = Converter.BitmapToHSVImage(image);
                var hsvResult = ContrastStretchingAlgorithm.StretchContrast(hsvImage, min, max);
                result = Converter.HSVImageToBitmap(hsvResult);
            }

            return result;
        }
    }
}
