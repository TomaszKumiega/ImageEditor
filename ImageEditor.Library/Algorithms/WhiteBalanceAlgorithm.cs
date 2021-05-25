using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Drawing;
using ImageEditor.Library.Helpers;

namespace ImageEditor.Library.Algorithms
{
    public class WhiteBalanceAlgorithm : IWhiteBalanceAlgorithm
    {
        private IHistogramStatisticsHelper HistogramStatistics { get; }

        public WhiteBalanceAlgorithm(IHistogramStatisticsHelper histogramStatistics)
        {
            HistogramStatistics = histogramStatistics;
        }

        public Bitmap WhiteBalance(Bitmap image)
        {
            float percentage = 0.05f;
            var rHistogram = new Histogram<byte>();
            var gHistogram = new Histogram<byte>();
            var bHistogram = new Histogram<byte>();

            var clonedImage = (Bitmap)image.Clone();

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            System.Drawing.Imaging.BitmapData bitmapData =
                clonedImage.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, image.PixelFormat);

            IntPtr ptr = bitmapData.Scan0;
            int bytes = Math.Abs(bitmapData.Stride) * clonedImage.Height;
            byte[] rgbValues = new byte[bytes];

            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            for(int i=0; i<rgbValues.Length; i+=3)
            {
                bHistogram.AddElement(rgbValues[i]);
                gHistogram.AddElement(rgbValues[i + 1]);
                rHistogram.AddElement(rgbValues[i + 2]);
            }

            (var rMin, var rMax) = HistogramStatistics.FindBoundariesOfXPercentage<byte>(rHistogram, percentage);
            (var gMin, var gMax) = HistogramStatistics.FindBoundariesOfXPercentage<byte>(gHistogram, percentage);
            (var bMin, var bMax) = HistogramStatistics.FindBoundariesOfXPercentage<byte>(bHistogram, percentage);
            
            var rA = 255 / (rMax - rMin);
            var rB = 0 - rA * rMin;
            var gA = 255 / (gMax - gMin);
            var gB = 0 - gA * gMin;
            var bA = (255) / (bMax - bMin);
            var bB = 0 - bA * bMin;

            int val = 0;

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                val = rA * rgbValues[i+2] + rB;
                rgbValues[i+2] = (byte)val;

                val = gA * rgbValues[i + 1] + gB;
                rgbValues[i + 1] = (byte)val;

                val = bA * rgbValues[i] + bB;
                rgbValues[i] = (byte)val;
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
            clonedImage.UnlockBits(bitmapData);

            return clonedImage;
        }
    }
}
