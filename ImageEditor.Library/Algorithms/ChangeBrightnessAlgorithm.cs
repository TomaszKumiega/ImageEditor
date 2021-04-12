using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeBrightnessAlgorithm : IChangeBrightnessAlgorithm
    {
        public HSVImage ChangeBrightness(HSVImage image, float brightnessDifference)
        {
            var result = new HSVImage(image.X, image.Y);

            for (int x = 0; x < image.X; x++)
            {
                for (int y = 0; y < image.Y; y++)
                {
                    result.Hue[x, y] = image.Hue[x, y];
                    result.Saturation[x, y] = image.Saturation[x, y];
                    result.Value[x,y] = image.Value[x, y] + brightnessDifference;
                }
            }

            return result;
        }
    }
}
