using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeTintAlgorithm : IChangeTintAlgorithm
    {
        public HSVImage ChangeTint(HSVImage image, float tint)
        {
            var hsvImage = new HSVImage(image.X, image.Y);

            for (int x=0; x < image.X; ++x)
            {
                for(int y=0; y<image.Y; ++y)
                {
                    var pixel = image.GetPixel(x, y);
                    var h = pixel.Hue + tint;
                    h = h > 360 ? h-360 : h < 0 ? 360+h : h;
                    var hsvColor = new HSVColor(h, pixel.Saturation, pixel.Value);
                    hsvImage.SetPixel(x, y, hsvColor);
                }
            }

            return hsvImage;
        }
    }
}
