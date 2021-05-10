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
            int[,] red = new int[bitmap.Width, bitmap.Height];
            int[,] green = new int[bitmap.Width, bitmap.Height];
            int[,] blue = new int[bitmap.Width, bitmap.Height];

            for (int x=0;x<bitmap.Width; x++)
            {
                for(int y=0;y<bitmap.Height; y++)
                {
                    var color = bitmap.GetPixel(x, y);
                    red[x, y] = color.R;
                    green[x, y] = color.G;
                    blue[x, y] = color.B;
                }
            }

            var image = new RGBImage(bitmap.Width, bitmap.Height, red, green, blue);
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

        public Color HSVPixelToColor(float h, float s, float v)
        {
            int hi = (int)Math.Floor(h / 60.0) % 6;
            double f = (h / 60.0) - Math.Floor(h / 60.0);

            double p = v * (1.0 - s);
            double q = v * (1.0 - (f * s));
            double t = v * (1.0 - ((1.0 - f) * s));

            Color ret;

            switch (hi)
            {
                case 0:
                    ret = GetRgb(v, t, p);
                    break;
                case 1:
                    ret = GetRgb(q, v, p);
                    break;
                case 2:
                    ret = GetRgb(p, v, t);
                    break;
                case 3:
                    ret = GetRgb(p, q, v);
                    break;
                case 4:
                    ret = GetRgb(t, p, v);
                    break;
                case 5:
                    ret = GetRgb(v, p, q);
                    break;
                default:
                    ret = Color.FromArgb(0xFF, 0x00, 0x00, 0x00);
                    break;
            }
            return ret;
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
