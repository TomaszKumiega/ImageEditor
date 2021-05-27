using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ContrastStretchingAlgorithm : IContrastStretchingAlgorithm
    {
        public HSVImage StretchContrast(HSVImage image, float min, float max)
        {
            var result = new HSVImage(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++) 
            {
                for (int y = 0; y < image.Height; y++)
                {
                    result.Hue[x, y] = image.Hue[x, y];
                    result.Saturation[x, y] = image.Saturation[x, y];

                    result.Value[x,y] = (image.Value[x, y] - min) / (max - min);

                    if (result.Value[x, y] > 1)
                    {
                        result.Value[x, y] = 1;
                    }
                    else if (result.Value[x, y] < 0)
                    {
                        result.Value[x, y] = 0;
                    }
                }
            }

            return result;
        }
    }
}
