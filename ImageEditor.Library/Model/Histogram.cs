using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public abstract class Histogram<XType>
    {
        public XType[] X { get; set; }
        public int[] Y { get; set; }
        public int NumberOfValues { get; set; }
    }
}
