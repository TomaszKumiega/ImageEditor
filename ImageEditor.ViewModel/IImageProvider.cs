using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IImageProvider
    {
        Bitmap OriginalImage { get; set; }
        Bitmap EditedImage { get; set; }
    }
}
