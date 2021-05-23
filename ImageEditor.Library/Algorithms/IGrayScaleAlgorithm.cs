﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Algorithms
{
    public interface IGrayscaleAlgorithm
    {
        Bitmap ChangeToGrayscale(Bitmap image);
    }
}
