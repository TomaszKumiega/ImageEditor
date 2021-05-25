using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public interface IHistogramStatisticsHelper
    {
        (T min, T max) FindBoundariesOfXPercentage<T>(Histogram<T> histogram, float percentage);
    }
}
