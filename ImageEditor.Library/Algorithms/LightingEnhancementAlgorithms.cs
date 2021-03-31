using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class LightingEnhancementAlgorithms : ILightingEnhancementAlgorithms
    {
        public HSVImage ChangeBrightness(HSVImage image, float brightnessDifference)
        {
            for (int x = 0; x < image.X; x++)
            {
                for (int y = 0; y < image.Y; y++)
                {
                    image.Value[x, y] += brightnessDifference;
                }
            }

            return image;
        }

        public HSVImage StretchContrast(HSVImage image, float min, float max)
        {
            for (int x = 0; x < image.X; x++)
            {
                for (int y = 0; y < image.Y; y++)
                {
                    image.Value[x, y] = (image.Value[x, y] - min) / (max - min);

                    if (image.Value[x, y] > 1)
                    {
                        image.Value[x, y] = 1;
                    }
                    else if (image.Value[x, y] < 0)
                    {
                        image.Value[x, y] = 0;
                    }
                }
            }

            return image;
        }
    }
}
