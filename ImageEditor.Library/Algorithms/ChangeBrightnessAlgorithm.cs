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
                    var r = image.R[x, y] + brightnessDifference;
                    var g = image.G[x, y] + brightnessDifference;
                    var b = image.B[x, y] + brightnessDifference;

                    // checks if value is in range of <0, 255>
                    result.R[x, y] = r > 255 ? 255 : r < 0 ? 0 : r; 
                    result.G[x, y] = g > 255 ? 255 : g < 0 ? 0 : g;
                    result.B[x, y] = b > 255 ? 255 : b < 0 ? 0 : b;
                }
            }

            return result;
        }
    }
}
