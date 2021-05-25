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

        public ColorEnhancementTools(IImageConverter converter, IChangeTintAlgorithm changeTintAlgorithm)
        {
            Converter = converter;
            ChangeTintAlgorithm = changeTintAlgorithm;
        }

        public Bitmap ChangeTint(Bitmap bitmap, float tint)
        {
            var actualTint = (float)(tint * 3.6);
            var hsvImage = Converter.BitmapToHSVImage(bitmap);
            var resultHSV = ChangeTintAlgorithm.ChangeTint(hsvImage, actualTint);
            var result = Converter.HSVImageToBitmap(resultHSV);
            return result;
        }
    }
}
