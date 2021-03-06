using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeSaturationAlgorithm : IChangeSaturationAlgorithm
    {
        public HSVImage ChangeSaturation(HSVImage image, float saturationGain)
        {
            var hsvImage = new HSVImage(image.Width, image.Height);

            for (int x = 0; x < image.Width; ++x)
            {
                for (int y = 0; y < image.Height; ++y)
                {
                    var pixel = image.GetPixel(x, y);
                    var sat = pixel.Saturation + saturationGain;
                    sat = sat > 1 ? 1 : sat < 0 ? 0 : sat;
                    var hsvColor = new HSVColor(pixel.Hue, sat, pixel.Value);
                    hsvImage.SetPixel(x, y, hsvColor);
                }
            }

            return hsvImage;
        }
    }
}
