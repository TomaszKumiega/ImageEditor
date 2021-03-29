using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class RGBImage
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int[,] R { get; set; }
        public int[,] G { get; set; }
        public int[,] B { get; set; }

        public RGBImage(int x, int y)
        {
            R = new int[x, y];
            G = new int[x, y];
            B = new int[x, y];
        }

        public RGBImage(int x, int y, int[,] r, int[,] g, int[,] b)
        {
            X = x;
            Y = y;
            R = r;
            G = g;
            B = b;
        }
    }
}
