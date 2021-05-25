using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public class HistogramStatisticsHelper : IHistogramStatisticsHelper
    {
        public (T min, T max) FindBoundariesOfXPercentage<T>(Histogram<T> histogram, float percentage)
        {
            var allValues = histogram.CountAll();
            var numberOfValuesToCut = (int)(allValues - (allValues * percentage));
            int cutValues = 0;
            T min = histogram.Keys.First();
            T max = histogram.Keys.Last();

            for(int i=0; i<histogram.Count; ++i)
            {
                var item = histogram.ElementAt(i);
                cutValues += item.Value;

                if (cutValues >= numberOfValuesToCut) break;
                min = item.Key;

                item = histogram.ElementAt(histogram.Count - 1 - i);
                cutValues += item.Value;

                if (cutValues >= numberOfValuesToCut) break;
                max = item.Key;
            }

            return (min, max);
        }
    }
}
