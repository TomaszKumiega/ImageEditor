using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageEditor.Library.Converter
{
    public class ImageConverter : IImageConverter
    {
        public HSVImage BitmapToHSVImage(Bitmap bitmap)
        {
            float[,] hue = new float[bitmap.Width, bitmap.Height];
            float[,] saturation = new float[bitmap.Width, bitmap.Height];
            float[,] value = new float[bitmap.Width, bitmap.Height];

            for(int x=0;x<bitmap.Width; x++)
            {
                for(int y=0;y<bitmap.Height;y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    hue[x,y] = color.GetHue();
                    saturation[x, y] = color.GetSaturation();
                    value[x, y] = color.GetBrightness();
                }
            }

            var image = new HSVImage(bitmap.Width, bitmap.Height, hue, saturation, value);
            return image;
        }

        public RGBImage BitmapToRGBImage(Bitmap bitmap)
        {
            var image = new RGBImage(bitmap.Width, bitmap.Height);

            for (int x=0;x<bitmap.Width; x++)
            {
                for(int y=0;y<bitmap.Height; y++)
                {
                    image.SetPixel(x, y, bitmap.GetPixel(x, y));
                }
            }

            return image;
        }

        public Bitmap HSVImageToBitmap(HSVImage image)
        {
            var bitmap = new Bitmap(image.X, image.Y);

            for(int x=0; x<image.X; x++)
            {
                for(int y=0; y<image.Y; y++)
                {
                    var color = HSVPixelToColor(image.Hue[x, y], image.Saturation[x, y], image.Value[x, y]);
                    bitmap.SetPixel(x, y, color);
                }
            }
            
            return bitmap;
        }

        public RGBImage HSVImageToRGBImage(HSVImage image)
        {
            var rgbImage = new RGBImage(image.X, image.Y);

            for(int x=0; x<image.X; x++)
            {
                for(int y=0; y<image.Y; y++)
                {
                    var color = HSVPixelToColor(image.Hue[x, y], image.Saturation[x, y], image.Value[x, y]);

                    rgbImage.R[x, y] = color.R;
                    rgbImage.G[x, y] = color.G;
                    rgbImage.B[x, y] = color.B;
                }
            }

            return rgbImage;
        }

        public Color HSVPixelToColor(float hue, float saturation, float value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        public Bitmap RGBImageToBitmap(RGBImage image)
        {
            var bmp = new Bitmap(image.X, image.Y);

            for(int x=0;x<image.X;x++)
            {
                for(int y=0;y<image.Y;y++)
                {
                    bmp.SetPixel(x, y, image.GetPixel(x, y));
                }
            }

            return bmp;
        }

        public HSVImage RGBImageToHSVImage(RGBImage image)
        {
            var hsvImage = new HSVImage(image.X, image.Y);

            for(int x=0; x<image.X; x++)
            {
                for(int y=0; y<image.Y; y++)
                {
                    var color = Color.FromArgb(image.R[x, y], image.G[x, y], image.B[x, y]);
                    hsvImage.Hue[x, y] = color.GetHue();
                    hsvImage.Saturation[x, y] = color.GetSaturation();
                    hsvImage.Value[x, y] = color.GetBrightness();
                }
            }

            return hsvImage;
        }

        private Color GetRgb(double r, double g, double b)
        {
            return Color.FromArgb(255, (byte)(r * 255.0), (byte)(g * 255.0), (byte)(b * 255.0));
        }
    }
}
