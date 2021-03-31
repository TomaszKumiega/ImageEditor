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
    }
}
