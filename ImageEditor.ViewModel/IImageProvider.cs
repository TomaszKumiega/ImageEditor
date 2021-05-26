﻿using ImageEditor.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IImageProvider
    {
        Bitmap OriginalImage { get; set; }
        Bitmap EditedImage { get; set; }
        string ImagePath { get; set; }
        void Reset();

        event PropertyChangedEventHandler PropertyChanged;
        event ResetEventHandler ResetEvent;
    }
}
