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
            var fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            return new Bitmap(fileStream);
        }

        public void SaveImage(Bitmap bitmap, string path)
        {
            var stream = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            bitmap.Save(stream, bitmap.RawFormat);
            stream.Close();
        }
    }
}
