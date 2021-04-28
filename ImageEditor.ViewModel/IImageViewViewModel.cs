using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IImageViewViewModel
    {
        IImageProvider ImageProvider { get; }
    }
}
