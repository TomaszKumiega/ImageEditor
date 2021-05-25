using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public interface IEffectsTools
    {
        Bitmap ChangeToGrayScale(Bitmap bitmap);
        Bitmap ChangeToNegative(Bitmap bitmap);
    }
}
