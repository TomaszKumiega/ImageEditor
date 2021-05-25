using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IChangeSaturationAlgorithm
    {
        HSVImage ChangeSaturation(HSVImage image, float saturationGain);
    }
}
