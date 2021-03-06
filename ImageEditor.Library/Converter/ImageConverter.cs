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
        private IColorConverter ColorConverter { get; }

        public ImageConverter(IColorConverter colorConverter)
        {
            ColorConverter = colorConverter;
        }

        public HSVImage BitmapToHSVImage(Bitmap image)
        {
            var hsvImage = new HSVImage(image.Width, image.Height);
            var bitmap = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int stride = bitmapData.Stride;

            unsafe
            {
                byte* p = (byte*)(void*)ptr;
                int offset = stride - bitmap.Width * 3;
                int width = bitmap.Width * 3;

                RGBColor rgbColor = new RGBColor();
                for(int y=0; y< bitmap.Height; ++y)
                {
                    for(int x=0; x< bitmap.Width; ++x)
                    {
                        rgbColor.Blue = p[0];
                        rgbColor.Green = p[1];
                        rgbColor.Red = p[2];

                        var hsvColor = ColorConverter.RGBToHSV(rgbColor);
                        hsvImage.SetPixel(x, y, hsvColor);
                        p += 3;
                    }
                    p += offset;
                }
            }

            bitmap.UnlockBits(bitmapData);

            return hsvImage;
        }

        public Bitmap HSVImageToBitmap(HSVImage image)
        {
            var bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format24bppRgb);

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bitmapData.Scan0;
            int stride = bitmapData.Stride;

            unsafe
            {
                byte* p = (byte*)(void*)ptr;
                int offset = stride - image.Width * 3;
                int width = image.Width * 3;

                for(int y=0; y<image.Height; ++y)
                {
                    for(int x=0; x<image.Width; ++x)
                    {
                        var hsvColor = image.GetPixel(x, y);
                        var rgbColor = ColorConverter.HSVToRGB(hsvColor);

                        p[0] = rgbColor.Blue;
                        p[1] = rgbColor.Green;
                        p[2] = rgbColor.Red;

                        p += 3;
                    }
                    p += offset;
                }
            }

            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
