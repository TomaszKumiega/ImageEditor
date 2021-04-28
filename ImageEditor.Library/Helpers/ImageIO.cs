using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public class ImageIO : IImageIO
    {
        public Bitmap LoadImage(string path)
        {
            return new Bitmap(path);
        }

        public void SaveImage(Bitmap bitmap, string path)
        {
            var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.Write);
            bitmap.Save(stream, bitmap.RawFormat);
            stream.Close();
        }
    }
}
