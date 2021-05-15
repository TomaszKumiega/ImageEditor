using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeBrightnessAlgorithm : IChangeBrightnessAlgorithm
    {
        public RGBImage ChangeBrightness(RGBImage image, int brightnessDifference)
        {
            var result = new RGBImage(image.X, image.Y);

            for (int x = 0; x < image.X; x++)
            {
                for (int y = 0; y < image.Y; y++)
                {
                    result.R[x, y] = (image.R[x,y] + brightnessDifference) > 255 ? 255 : image.R[x, y] + brightnessDifference;
                    result.G[x, y] = (image.G[x,y] + brightnessDifference) > 255 ? 255 : image.G[x, y] + brightnessDifference;
                    result.B[x, y] = (image.B[x,y] + brightnessDifference) > 255 ? 255 : image.B[x, y] + brightnessDifference;
                }
            }

            return result;
        }
    }
}
