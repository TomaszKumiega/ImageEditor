using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeBrightnessAlgorithm : IChangeBrightnessAlgorithm
    {
        public Bitmap ChangeBrightness(Bitmap image, int brightnessDifference)
        {
            var result = (Bitmap) image.Clone();

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    var color = result.GetPixel(x, y);

                    var r = color.R + brightnessDifference;
                    var g = color.G + brightnessDifference;
                    var b = color.B + brightnessDifference;
                    
                    r = r > 255 ? 255 : r < 0 ? 0 : r;
                    g = g > 255 ? 255 : g < 0 ? 0 : g;
                    b = b > 255 ? 255 : b < 0 ? 0 : b;

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return result;
        }
    }
}
