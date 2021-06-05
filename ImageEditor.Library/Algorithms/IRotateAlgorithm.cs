using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IRotateAlgorithm
    {
        Bitmap Rotate(Bitmap bitmap, float angle);
    }
}
