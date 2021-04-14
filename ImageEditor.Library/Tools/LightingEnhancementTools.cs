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

        public LightingEnhancementTools(IImageConverter converter, IChangeBrightnessAlgorithm changeBrightnessAlgorithm)
        {
            Converter = converter;
            ChangeBrightnessAlgorithm = changeBrightnessAlgorithm;
        }

        public Bitmap ChangeBrightness(Bitmap image, float brightness)
        {
            var scaledBrightness = brightness / 100;
            var hsvImage = Converter.BitmapToHSVImage(image);
            var hsvResult = ChangeBrightnessAlgorithm.ChangeBrightness(hsvImage, scaledBrightness);
            var result = Converter.HSVImageToBitmap(hsvResult);

            return result;
        }
    }
}
