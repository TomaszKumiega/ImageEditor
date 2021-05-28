using ImageEditor.Library.Helpers;
using ImageEditor.ViewModel.Commands;
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

        public SaveImageCommand SaveImageCommand { get; }
        public ResetChangesCommand ResetChangesCommand { get; }

        public MenuViewModel(IImageProvider imageProvider, IImageIO imageIO, ICommandFactory commandFactory)
        {
            SaveImageCommand = commandFactory.GetSaveImageCommand(this);
            ResetChangesCommand = commandFactory.GetResetChangesCommand(this);
            ImageProvider = imageProvider;
            ImageIO = imageIO;
        }

        public void LoadImage(string path)
        {
            var image = ImageIO.LoadImage(path);
            ImageProvider.OriginalImage = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            ImageProvider.EditedImage = image.Clone(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            ImageProvider.ImagePath = path;
            ImageProvider.Reset();
        }

        public void Reset()
        {
            ImageProvider.Reset();
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
