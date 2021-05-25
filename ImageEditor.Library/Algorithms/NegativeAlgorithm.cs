using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class NegativeAlgorithm : INegativeAlgorithm
    {
        public Bitmap ChangeToNegative(Bitmap image)
        {
            var clonedImage = (Bitmap)image.Clone();

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                clonedImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, clonedImage.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * clonedImage.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i = 0; i < rgbValues.Length-2; i++)
            {
                rgbValues[i] = (byte)(255 - rgbValues[i]);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            clonedImage.UnlockBits(bitmapData);

            return clonedImage;
        }
    }
}
