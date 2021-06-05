using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public class RotateAlgorithm : IRotateAlgorithm
    {
        public Bitmap Rotate(Bitmap bitmap, float angle)
        {
            var resultBitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            using(Graphics gdi = Graphics.FromImage(resultBitmap))
            {
                gdi.TranslateTransform((float)bitmap.Width / 2, (float)bitmap.Height / 2);
                gdi.RotateTransform(angle);
                gdi.TranslateTransform((float)-bitmap.Width / 2, (float)-bitmap.Height / 2);
            }

            return resultBitmap;
        }
    }
}
