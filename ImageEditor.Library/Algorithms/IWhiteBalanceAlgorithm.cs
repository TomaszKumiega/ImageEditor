using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IWhiteBalanceAlgorithm
    {
        Bitmap WhiteBalance(Bitmap image);
    }
}
