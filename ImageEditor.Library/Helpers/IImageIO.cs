using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public interface IImageIO
    {
        void SaveImage(Bitmap bitmap, string path);
        Bitmap LoadImage(string path);
    }
}
