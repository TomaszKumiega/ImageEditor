using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class HSVImage
    {
        public int X { get; set; }
        public int Y { get; set; }
        public float[,] Hue { get; set; }
        public float[,] Saturation { get; set; }
        public float[,] Value { get; set; }

        public HSVImage(int x, int y, float[,] hue, float[,] saturation, float[,] value)
        {
            X = x;
            Y = y;
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }
    }
}
