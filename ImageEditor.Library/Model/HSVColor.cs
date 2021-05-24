using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class HSVColor
    {
        public float Hue { get; set; }
        public float Saturation { get; set; }
        public float Value { get; set; }

        public HSVColor()
        {

        }

        public HSVColor(float h, float s, float v)
        {
            Hue = h;
            Saturation = s;
            Value = v;
        }
    }
}
