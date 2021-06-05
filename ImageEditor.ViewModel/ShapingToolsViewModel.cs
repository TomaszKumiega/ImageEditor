using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ImageEditor.ViewModel
{
    public class ShapingToolsViewModel : IShapingToolsViewModel, INotifyPropertyChanged
    {
        private float _rotateAngle;

        public event PropertyChangedEventHandler PropertyChanged;

        private IShapingTools ShapingTools { get; }
        private IImageProvider ImageProvider { get; }

        public ShapingToolsViewModel(IShapingTools shapingTools, IImageProvider imageProvider)
        {
            ShapingTools = shapingTools;
            ImageProvider = imageProvider;
            ImageProvider.ResetEvent += OnReset;
            ImageProvider.ApplyEvent += OnApply;
        }

        public float RotateAngle 
        {
            get => _rotateAngle; 
            set
            {
                if(value == 0 && _rotateAngle != 0)
                {
                    RemoveRotateOperation();
                }
                else if(value != _rotateAngle)
                {
                    _rotateAngle = value;
                    ApplyRotateOperation();
                }
            }
        }

        private void RemoveRotateOperation()
        {
            ImageProvider.RemoveOperation(Operation.Rotate);
        }

        private void ApplyRotateOperation()
        {
            ImageProvider.ApplyOperation(Operation.Rotate);
        }

        private void OnApply(object sender, ApplyEventArgs args)
        {
            switch(args.Operation)
            {
                case Operation.Rotate:  Rotate();
                    break;
            }
        }

        private void OnReset(object sender, EventArgs args)
        {
            _rotateAngle = 0;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RotateAngle"));
        }

        private void Rotate()
        {
            ImageProvider.EditedImage = ShapingTools.Rotate(ImageProvider.EditedImage, _rotateAngle);
        }
    }
}
