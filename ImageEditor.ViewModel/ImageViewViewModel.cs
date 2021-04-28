using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class ImageViewViewModel : IImageViewViewModel
    {
        public IImageProvider ImageProvider { get; }

        public ImageViewViewModel(IImageProvider imageProvider)
        {
            ImageProvider = imageProvider;
        }
    }
}
