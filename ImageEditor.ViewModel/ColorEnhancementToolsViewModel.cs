using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Commands;
using ImageEditor.ViewModel.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel
{
    public class ColorEnhancementToolsViewModel : IColorEnhancementToolsViewModel, INotifyPropertyChanged
    {
        private float _tint;
        private float _saturation;

        public event PropertyChangedEventHandler PropertyChanged;

        private IColorEnhancementTools ColorEnhancementTools { get; }
        private IImageProvider ImageProvider { get; }

        public ICommand WhiteBalanceCommand { get; }

        public ColorEnhancementToolsViewModel(IColorEnhancementTools colorEnhancementTools, IImageProvider imageProvider, ICommandFactory commandFactory)
        {
            ColorEnhancementTools = colorEnhancementTools;
            ImageProvider = imageProvider;
            WhiteBalanceCommand = commandFactory.GetWhiteBalanceCommand(this);
            ImageProvider.ResetEvent += OnReset;
            ImageProvider.ApplyEvent += OnApply;
            _tint = 0;
            _saturation = 0;
        }

        public float Tint
        {
            get => _tint;
            set
            {
                if(value == 0 && _tint != 0)
                {
                    RemoveTint();
                }
                else if(value != _tint)
                {
                    _tint = value;
                    ApplyTint();
                }
            }
        }

        public float Saturation
        {
            get => _saturation;
            set
            {
                if(value == 0 && _saturation != 0)
                {
                    RemoveSaturation();
                }
                else if(value != _saturation)
                {
                    _saturation = value;
                    ApplySaturation();
                }
            }
        }

        private void OnReset(object sender, EventArgs args)
        {
            _saturation = 0;
            _tint = 0;
            OnPropertyChanged("Tint");
            OnPropertyChanged("Saturation");
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void ApplyTint()
        {
            ImageProvider.ApplyOperation(Operation.Tint);
        }

        private void ApplySaturation()
        {
            ImageProvider.ApplyOperation(Operation.Saturation);
        }

        public void ApplyWhiteBalance()
        {
            ImageProvider.ApplyOperation(Operation.WhiteBalance);
        }

        private void RemoveTint()
        {
            ImageProvider.RemoveOperation(Operation.Tint);
        }

        private void RemoveSaturation()
        {
            ImageProvider.RemoveOperation(Operation.Saturation);
        }

        private void RemoveWhiteBalance()
        {
            ImageProvider.RemoveOperation(Operation.WhiteBalance);
        }

        private void OnApply(object sender, ApplyEventArgs args)
        {
            switch(args.Operation)
            {
                case Operation.WhiteBalance: WhiteBalance();
                    break;
                case Operation.Tint: ChangeTint();
                    break;
                case Operation.Saturation: ChangeSaturation();
                    break;
            }
        }

        private void ChangeTint()
        {
            ImageProvider.EditedImage = ColorEnhancementTools.ChangeTint(ImageProvider.EditedImage, _tint);
        }

        private void ChangeSaturation()
        {
            ImageProvider.EditedImage = ColorEnhancementTools.ChangeSaturation(ImageProvider.EditedImage, _saturation);
        }
        private void WhiteBalance()
        {
            ImageProvider.EditedImage = ColorEnhancementTools.WhiteBalance(ImageProvider.EditedImage);
        }        
    }
}
