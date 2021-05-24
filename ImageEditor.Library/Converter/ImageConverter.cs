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

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * image.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for(int i=0; i<rgbValues.Length; i+=3)
            {
                var rgbColor = new RGBColor();
                rgbColor.Blue = rgbValues[i];
                rgbColor.Green = rgbValues[i + 1];
                rgbColor.Red = rgbValues[i + 2];

                var height = (i / 3) % image.Width;
                var width = (i / 3) - (height * image.Width);
                var hsvColor = ColorConverter.RGBToHSV(rgbColor);

                hsvImage.SetPixel(width, height, hsvColor);
            }

            image.UnlockBits(bitmapData);

            return hsvImage;
        }

        public Bitmap HSVImageToBitmap(HSVImage image)
        {
            var bitmap = new Bitmap(image.X, image.Y);

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for(int i=0;i<rgbValues.Length;i+=3)
            {
                var height = (i / 3) % image.X;
                var width = (i / 3) - (height * image.X);

                var hsvColor = image.GetPixel(width, height);
                var rgbColor = ColorConverter.HSVToRGB(hsvColor);

                rgbValues[i] = rgbColor.Blue;
                rgbValues[i + 1] = rgbColor.Green;
                rgbValues[i + 2] = rgbColor.Red;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }
    }
}
