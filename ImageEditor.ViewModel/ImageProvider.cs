using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class ImageProvider : IImageProvider, INotifyPropertyChanged
    {
        private Bitmap _originalImage;
        private Bitmap _editedImage;
        private string _imagePath;

        public Bitmap OriginalImage 
        {
            get => _originalImage;
            set
            {
                _originalImage = value;
                OnPropertyChanged("OriginalImage");
            }
        }
        public Bitmap EditedImage 
        { 
            get => _editedImage; 
            set
            {
                _editedImage = value;
                OnPropertyChanged("EditedImage");
            }
        }
        public string ImagePath 
        {
            get => _imagePath; 
            set
            {
                _imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
