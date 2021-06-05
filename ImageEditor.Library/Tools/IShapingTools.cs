using ImageEditor.Library.Algorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public interface IShapingTools
    {
        Bitmap Rotate(Bitmap bitmap, float angle);
    }
}
