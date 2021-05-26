using ImageEditor.Library.Tools;
using ImageEditor.ViewModel.Commands;
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
            PropertyChanged += ChangeTint;
            PropertyChanged += ChangeSaturation;
            ImageProvider.ResetEvent += OnReset;
            _tint = 0;
            _saturation = 0;
        }

        public float Tint
        {
            get => _tint;
            set
            {
                if(value != _tint)
                {
                    _tint = value;
                    OnPropertyChanged("Tint");
                }
            }
        }

        public float Saturation
        {
            get => _saturation;
            set
            {
                if(value != _saturation)
                {
                    _saturation = value;
                    OnPropertyChanged("Saturation");
                }
            }
        }

        private void OnReset(object sender, EventArgs args)
        {
            Saturation = 0;
            Tint = 0;
        }

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void ChangeTint(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "Tint") return;
            ImageProvider.EditedImage = ColorEnhancementTools.ChangeTint(ImageProvider.OriginalImage, _tint);
        }

        public void ChangeSaturation(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName != "Saturation") return;
            ImageProvider.EditedImage = ColorEnhancementTools.ChangeSaturation(ImageProvider.OriginalImage, _saturation);
        }

        public void WhiteBalance()
        {
            ImageProvider.EditedImage = ColorEnhancementTools.WhiteBalance(ImageProvider.OriginalImage);
        }
    }
}
