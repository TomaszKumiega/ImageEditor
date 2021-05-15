using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IChangeBrightnessAlgorithm
    {
        RGBImage ChangeBrightness(RGBImage image, int brightnessDifference);
    }
}
