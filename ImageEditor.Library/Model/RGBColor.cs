using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class RGBColor
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }

        public RGBColor()
        {

        }

        public RGBColor(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public RGBColor(int red, int green, int blue)
        {
            Red = (byte)red;
            Green = (byte)green;
            Blue = (byte)blue;
        }
    }
}
