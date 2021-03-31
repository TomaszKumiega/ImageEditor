using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface ILightingEnhancementAlgorithms
    {
        HSVImage ChangeBrightness(HSVImage image, float brightnessDifference);
        HSVImage StretchContrast(HSVImage image, float min, float max);
    }
}
