using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Converter
{
    public interface IImageConverter
    {
        HSVImage BitmapToHSVImage(Bitmap bitmap);
        Bitmap HSVImageToBitmap(HSVImage image);
        Color HSVPixelToColor(float hue, float saturation, float value);
    }
}
