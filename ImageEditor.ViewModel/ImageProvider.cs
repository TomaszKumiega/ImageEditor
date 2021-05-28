using ImageEditor.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class ImageProvider : IImageProvider, INotifyPropertyChanged
    {
        private Bitmap _originalImage;
        private Bitmap _editedImage;
        private string _imagePath;

        private List<Operation> AppliedOperations { get; set; }

        public ImageProvider()
        {
            AppliedOperations = new List<Operation>();
        }

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
        public event ResetEventHandler ResetEvent;
        public event ApplyEventHandler ApplyEvent;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        private void ReapplyAll()
        {
            foreach(var t in AppliedOperations)
            {
                ApplyEvent?.Invoke(this, new ApplyEventArgs(t));
            }
        }

        public void RemoveOperation(Operation op)
        {
            if(AppliedOperations.Contains(op))
            {
                AppliedOperations.Remove(op);
            }
        }

        public void ApplyOperation(Operation op)
        {
            if(!AppliedOperations.Contains(op))
            {
                AppliedOperations.Add(op);
                AppliedOperations = AppliedOperations.OrderBy(x => (int)x).ToList();
            }
            ReapplyAll();
        }

        public void Reset()
        {
            EditedImage = (Bitmap)OriginalImage.Clone();
            AppliedOperations.Clear();
            ResetEvent?.Invoke(this, new EventArgs());
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EditedImage"));
        }
    }
}
