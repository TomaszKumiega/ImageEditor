using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Converter
{
    public interface IColorConverter
    {
        HSVColor RGBToHSV(RGBColor color);
        RGBColor HSVToRGB(HSVColor color);
    }
}
