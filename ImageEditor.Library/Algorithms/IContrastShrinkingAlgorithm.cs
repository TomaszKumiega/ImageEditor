using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IContrastShrinkingAlgorithm
    {
        HSVImage ShrinkContrast(HSVImage image, float min, float max);
    }
}
