using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Converter
{
    public class ColorConverter : IColorConverter
    {
        public RGBColor HSVToRGB(HSVColor color)
        {
            int hi = Convert.ToInt32(Math.Floor(color.Hue / 60)) % 6;
            double f = color.Hue / 60 - Math.Floor(color.Hue / 60);

            color.Value = color.Value * 255;
            int v = Convert.ToInt32(color.Value);
            int p = Convert.ToInt32(color.Value * (1 - color.Saturation));
            int q = Convert.ToInt32(color.Value * (1 - f * color.Saturation));
            int t = Convert.ToInt32(color.Value * (1 - (1 - f) * color.Saturation));

            if (hi == 0)
                return new RGBColor(v, t, p);
            else if (hi == 1)
                return new RGBColor(q, v, p);
            else if (hi == 2)
                return new RGBColor(p, v, t);
            else if (hi == 3)
                return new RGBColor(p, q, v);
            else if (hi == 4)
                return new RGBColor(t, p, v);
            else
                return new RGBColor(v, p, q);
        }

        public HSVColor RGBToHSV(RGBColor color)
        {
            float delta, min;
            float h = 0, s, v;

            min = Math.Min(Math.Min(color.Red, color.Green), color.Blue);
            v = Math.Max(Math.Max(color.Red, color.Green), color.Blue);
            delta = v - min;

            if (v == 0.0)
                s = 0;
            else
                s = delta / v;

            if (s == 0)
                h = 0.0f;

            else
            {
                if (color.Red == v)
                    h = (color.Green - color.Blue) / delta;
                else if (color.Green == v)
                    h = 2 + (color.Blue - color.Red) / delta;
                else if (color.Blue == v)
                    h = 4 + (color.Red - color.Green) / delta;

                h *= 60;

                if (h < 0.0)
                    h = h + 360;
            }

            return new HSVColor(h, s, v / 255);
        }
    }
}
