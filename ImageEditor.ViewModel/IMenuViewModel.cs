using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IMenuViewModel
    {
        void LoadImage(string path);
        void SaveImage();
        void SaveImageAs(string path);
        void Reset();
    }
}
