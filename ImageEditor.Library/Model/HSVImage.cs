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

        public HSVImage(int x, int y)
        {
            X = x;
            Y = y;
            Hue = new float[x,y];
            Saturation = new float[x, y];
            Value = new float[x, y];
        }

        public HSVImage(int x, int y, float[,] hue, float[,] saturation, float[,] value)
        {
            X = x;
            Y = y;
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }

        public void SetPixel(int x, int y, HSVColor color)
        {
            if (x > X || y > Y || x < 0 || y < 0) throw new ArgumentException("Index out of bounds");

            Hue[x, y] = color.Hue;
            Saturation[x, y] = color.Saturation;
            Value[x, y] = color.Value;
        }

        public HSVColor GetPixel(int x, int y)
        {
            if (x > X || y > Y || x < 0 || y < 0) throw new ArgumentException("Index out of bounds");
            return new HSVColor(Hue[x,y], Saturation[x,y], Value[x,y]);
        }
    }
}
