using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public interface ILightingEnhancementTools
    {
        /// <summary>
        /// Changes brightness of an image. Brightness is a value between -100 to 100.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        Bitmap ChangeBrightness(Bitmap image, float brightness);

        /// <summary>
        /// Changes contrast of an image. Contrast is a value between -100 to 100.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="contrast"></param>
        /// <returns></returns>
        Bitmap ChangeContrast(Bitmap image, float contrast)
    }
}
