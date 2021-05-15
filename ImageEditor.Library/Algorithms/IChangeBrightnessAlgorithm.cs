using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IChangeBrightnessAlgorithm
    {
        Bitmap ChangeBrightness(Bitmap image, int brightnessDifference);
    }
}
