using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class ImageProvider : IImageProvider
    {
        public Bitmap OriginalImage { get; set; }
        public Bitmap EditedImage { get; set; }
    }
}
