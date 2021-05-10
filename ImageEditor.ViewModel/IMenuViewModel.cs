using ImageEditor.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IMenuViewModel
    {
        SaveImageCommand SaveImageCommand { get; }
        ResetChangesCommand ResetChangesCommand { get; }
        void LoadImage(string path);
        void SaveImage();
        void SaveImageAs(string path);
        void Reset();
    }
}
