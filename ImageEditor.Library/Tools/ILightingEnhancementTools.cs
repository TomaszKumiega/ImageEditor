using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public interface ILightingEnhancementTools
    {
        Bitmap ChangeBrightness(Bitmap image, float brightness);
    }
}
