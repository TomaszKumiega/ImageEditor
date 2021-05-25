using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class ColorEnhancementTools : IColorEnhancementTools
    {
        private IImageConverter Converter { get; }
        private IChangeTintAlgorithm ChangeTintAlgorithm { get; }
        private IChangeSaturationAlgorithm ChangeSaturationAlgorithm { get; }

        public ColorEnhancementTools(IImageConverter converter, IChangeTintAlgorithm changeTintAlgorithm, IChangeSaturationAlgorithm changeSaturationAlgorithm)
        {
            Converter = converter;
            ChangeTintAlgorithm = changeTintAlgorithm;
            ChangeSaturationAlgorithm = changeSaturationAlgorithm;
        }

        public Bitmap ChangeTint(Bitmap bitmap, float tint)
        {
            var actualTint = (float)(tint * 3.6);
            var hsvImage = Converter.BitmapToHSVImage(bitmap);
            var resultHSV = ChangeTintAlgorithm.ChangeTint(hsvImage, actualTint);
            var result = Converter.HSVImageToBitmap(resultHSV);
            return result;
        }

        public Bitmap ChangeSaturation(Bitmap bitmap, float saturation)
        {
            var actualSaturation = (float)(saturation / 100);
            var hsvImage = Converter.BitmapToHSVImage(bitmap);
            var resultHSV = ChangeSaturationAlgorithm.ChangeSaturation(hsvImage, actualSaturation);
            var result = Converter.HSVImageToBitmap(resultHSV);
            return result;
        }
    }
}
