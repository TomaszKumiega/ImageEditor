using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Converter
{
    public interface IImageConverter
    {
        RGBImage BitmapToRGBImage(Bitmap bitmap);
        HSVImage BitmapToHSVImage(Bitmap bitmap);
        HSVImage RGBImageToHSVImage(RGBImage image);
        RGBImage HSVImageToRGBImage(HSVImage image);
        Bitmap RGBImageToBitmap(RGBImage image);
        Bitmap HSVImageToBitmap(HSVImage image);
        Color HSVPixelToColor(float hue, float saturation, float value);
    }
}
