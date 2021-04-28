﻿using ImageEditor.Library.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class MenuViewModel : IMenuViewModel
    {
        private IImageProvider ImageProvider { get; }
        private IImageIO ImageIO { get; }

        public MenuViewModel(IImageProvider imageProvider, IImageIO imageIO)
        {
            ImageProvider = imageProvider;
            ImageIO = imageIO;
        }

        public void LoadImage(string path)
        {
            ImageProvider.OriginalImage = ImageIO.LoadImage(path);
            ImageProvider.EditedImage = (Bitmap) ImageProvider.OriginalImage.Clone();
            ImageProvider.ImagePath = path;
        }

        public void Reset()
        {
            ImageProvider.EditedImage = (Bitmap) ImageProvider.OriginalImage.Clone();
        }

        public void SaveImage()
        {
            ImageIO.SaveImage(ImageProvider.EditedImage, ImageProvider.ImagePath);
        }

        public void SaveImageAs(string path)
        {
            ImageIO.SaveImage(ImageProvider.EditedImage, path);
            ImageProvider.ImagePath = path;
        }
    }
}