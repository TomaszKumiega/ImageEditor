using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class IntensityHistogram : Histogram<float>
    {
        public IntensityHistogram(float[] intensityValues, float minRange, float maxRange)
        {
            NumberOfValues = intensityValues.Length;

            X = intensityValues.Distinct().ToArray();
            X = X.OrderBy(x => x).ToArray();

            Y = new int[X.Length];

            for(int i=0; i<X.Length; i++)
            {
                Y[i] = intensityValues.Count(x => x == X[i]);
            }
        }

        public int GetQuantityOfX(float x)
        {
            if (X.Contains(x))
            {
                var index = X.ToList().IndexOf(x);
                return Y[index];
            }
            else
            {
                return 0;

            }
        }
    }
}
