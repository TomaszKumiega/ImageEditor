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

            for (int i=0; i<rgbValues.Length-2; i++)
            {
                var val = (int) rgbValues[i];
                val += brightnessDifference;
                val = val > 255 ? 255 : val < 0 ? 0 : val;
                rgbValues[i] = (byte) val;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

            clonedImage.UnlockBits(bitmapData);

            return clonedImage;
        }

        public HSVImage ChangeBrightness(HSVImage image, float brightnessDiffrence)
        {
            var hsvImage = new HSVImage(image.Width, image.Height);

            for(int x=0;x<image.Width;++x)
            {
                for(int y=0;y<image.Height;++y)
                {
                    var hsvColor = image.GetPixel(x, y);
                    hsvColor.Value += brightnessDiffrence;
                    hsvColor.Value = hsvColor.Value > 1 ? 1 : hsvColor.Value < 0 ? 0 : hsvColor.Value;
                    hsvImage.SetPixel(x, y, hsvColor);
                }
            }

            return hsvImage;
        }
    }
}
