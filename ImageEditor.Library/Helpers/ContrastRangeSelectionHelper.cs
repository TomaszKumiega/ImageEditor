using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public class ContrastRangeSelectionHelper : IContrastRangeSelectionHelper
    {
        public void ContrastStretchingRangeSelection(IntensityHistogram histogram, out float minRange, out float maxRange)
        {
            float fraction = 0.05f;

            var expectedNumberOfCutValues = histogram.NumberOfValues * fraction;
            var numberOfCutValues = 0;

            minRange = 0;
            maxRange = 0;

            for(int i=0;i<histogram.Y.Length/2;i++)
            {
                numberOfCutValues += histogram.Y[i];

                if (numberOfCutValues >= expectedNumberOfCutValues) break;

                minRange = histogram.X[i];

                numberOfCutValues += histogram.Y[histogram.Y.Length - i - 1];

                if (numberOfCutValues > expectedNumberOfCutValues) break;

                maxRange = histogram.X[histogram.X.Length - i - 1];
            }
        }
    }
}
