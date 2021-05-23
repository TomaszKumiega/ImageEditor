using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class GrayscaleAlgorithm : IGrayscaleAlgorithm
    {
        public Bitmap ChangeToGrayscale(Bitmap image)
        {
            var clonedImage = (Bitmap)image.Clone();

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                clonedImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, clonedImage.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * clonedImage.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for(int i=0; i<rgbValues.Length; i+=3)
            {
                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = (byte)(.299 * rgbValues[i] + .587 * rgbValues[i + 1] + .114 * rgbValues[i + 2]);
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            clonedImage.UnlockBits(bitmapData);

            return clonedImage;
        }
    }
}
