using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel
{
    public interface IColorEnhancementToolsViewModel
    {
        float Tint { get; set; }
        float Saturation { get; set; }
    }
}
