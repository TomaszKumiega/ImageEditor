using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ImageEditor.ViewModel
{
    public interface IColorEnhancementToolsViewModel
    {
        ICommand WhiteBalanceCommand { get; }
        float Tint { get; set; }
        float Saturation { get; set; }

        void WhiteBalance();
    }
}
