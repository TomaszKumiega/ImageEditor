using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class SharpeningAlgorithm : ISharpeningAlgorithm
    {
        public Bitmap Sharpen(Bitmap image, double strength)
        {
            Bitmap resultImage = new Bitmap(image.Width, image.Height);

            int filterWidth = 3;
            int filterHeight = 3;
            int width = image.Width;
            int height = image.Height;

            double[,] filter = new double[filterWidth, filterWidth];
            filter[0, 0] = filter[0, 1] = filter[0, 2] = filter[1, 0] = filter[1, 2] = filter[2, 0] = filter[2, 1] = filter[2, 2] = -1;
            filter[1, 1] = 9;

            double factor = strength / 9;
            double bias = 1.0 - strength;

            var rectangle = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData bitmapData = resultImage.LockBits(rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = bitmapData.Stride * height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            int r, g, b;
            double red = 0, green = 0, blue = 0;

            for (int i = 0; i < rgbValues.Length; ++i)
            {
                for (int x = 0; x < filterWidth; ++x)
                {
                    for (int y = 0; y < filterHeight; ++y)
                    {
                        red += rgbValues[i + 2] * filter[x, y];
                        green += rgbValues[i + 1] * filter[x, y];
                        blue += rgbValues[i + 1] * filter[x, y];
                    }

                    r = Math.Min(Math.Max((int)(factor * red + bias), 0), 255);
                    g = Math.Min(Math.Max((int)(factor * green + bias), 0), 255);
                    b = Math.Min(Math.Max((int)(factor * blue + bias), 0), 255);

                    rgbValues[i + 2] = (byte)r;
                    rgbValues[i + 1] = (byte)g;
                    rgbValues[i] = (byte)b;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            resultImage.UnlockBits(bitmapData);
            return resultImage;
        }
    }
}
