using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IContrastStretchingAlgorithm
    {
        HSVImage StretchContrast(HSVImage image, float min, float max);
    }
}
