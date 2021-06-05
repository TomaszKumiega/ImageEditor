using ImageEditor.Library.Algorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class ShapingTools : IShapingTools
    {
        private IRotateAlgorithm RotateAlgorithm { get; }

        public ShapingTools(IRotateAlgorithm rotateAlgorithm)
        {
            RotateAlgorithm = rotateAlgorithm;
        }

        public Bitmap Rotate(Bitmap bitmap, float angle)
        {
            return RotateAlgorithm.Rotate(bitmap, angle);
        }
    }
}
