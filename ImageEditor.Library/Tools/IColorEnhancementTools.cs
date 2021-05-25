using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public interface IColorEnhancementTools
    {
        Bitmap ChangeTint(Bitmap bitmap, float tint);
    }
}
