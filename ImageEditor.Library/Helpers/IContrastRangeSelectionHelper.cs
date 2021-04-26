using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public interface IContrastRangeSelectionHelper
    {
        void ContrastStretchingRangeSelection(IntensityHistogram histogram, out float minRange, out float maxRange);
    }
}
