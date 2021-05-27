using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class HSVImage
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public float[,] Hue { get; set; }
        public float[,] Saturation { get; set; }
        public float[,] Value { get; set; }

        public HSVImage(int width, int height)
        {
            Width = width;
            Height = height;
            Hue = new float[width,height];
            Saturation = new float[width, height];
            Value = new float[width, height];
        }

        public HSVImage(int x, int y, float[,] hue, float[,] saturation, float[,] value)
        {
            Width = x;
            Height = y;
            Hue = hue;
            Saturation = saturation;
            Value = value;
        }

        public void SetPixel(int x, int y, HSVColor color)
        {
            if (x > Width || y > Height || x < 0 || y < 0) throw new ArgumentException("Index out of bounds");

            Hue[x, y] = color.Hue;
            Saturation[x, y] = color.Saturation;
            Value[x, y] = color.Value;
        }

        public HSVColor GetPixel(int x, int y)
        {
            if (x > Width || y > Height || x < 0 || y < 0) throw new ArgumentException("Index out of bounds");
            return new HSVColor(Hue[x,y], Saturation[x,y], Value[x,y]);
        }
    }
}
