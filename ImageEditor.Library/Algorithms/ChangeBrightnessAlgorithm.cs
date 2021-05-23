using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class ChangeBrightnessAlgorithm : IChangeBrightnessAlgorithm
    {
        public Bitmap ChangeBrightness(Bitmap image, int brightnessDifference)
        {
            var clonedImage = (Bitmap) image.Clone();

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                clonedImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, clonedImage.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * clonedImage.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for (int i=0; i<rgbValues.Length; i++)
            {
                var val = (int) rgbValues[i];
                val += brightnessDifference;
                if (val > 255) val = 255;
                if (val < 0) val = 0;
                rgbValues[i] = (byte) val;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            clonedImage.UnlockBits(bitmapData);

            return clonedImage;
        }
    }
}
