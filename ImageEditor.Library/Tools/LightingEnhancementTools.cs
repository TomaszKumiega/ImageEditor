using ImageEditor.Library.Algorithms;
using ImageEditor.Library.Converter;
using ImageEditor.Library.Helpers;
using ImageEditor.Library.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class LightingEnhancementTools : ILightingEnhancementTools
    {
        private IImageConverter Converter { get; }
        private IChangeBrightnessAlgorithm ChangeBrightnessAlgorithm { get; }
        private IContrastStretchingAlgorithm ContrastStretchingAlgorithm { get; }
        private IContrastShrinkingAlgorithm ContrastShrinkingAlgorithm { get; }
        private IContrastRangeSelectionHelper ContrastRangeSelection { get; }
        private IFlatten2DArrayHelper<float> Flatten2DArrayHelper { get; }

        public LightingEnhancementTools(IImageConverter converter, IChangeBrightnessAlgorithm changeBrightnessAlgorithm, 
            IContrastStretchingAlgorithm contrastStretchingAlgorithm, IContrastShrinkingAlgorithm contrastShrinkingAlgorithm, 
            IContrastRangeSelectionHelper contrastRangeSelection, IFlatten2DArrayHelper<float> flatten2DArrayHelper)
        {
            Converter = converter;
            ChangeBrightnessAlgorithm = changeBrightnessAlgorithm;
            ContrastStretchingAlgorithm = contrastStretchingAlgorithm;
            ContrastShrinkingAlgorithm = contrastShrinkingAlgorithm;
            ContrastRangeSelection = contrastRangeSelection;
            Flatten2DArrayHelper = flatten2DArrayHelper;
        }

        public Bitmap ChangeBrightness(Bitmap image, float brightness)
        {
            var scaledBrightness = (int) (brightness * 2.55);
            var rgbImage = Converter.BitmapToRGBImage(image);
            var rgbResult = ChangeBrightnessAlgorithm.ChangeBrightness(rgbImage, scaledBrightness);
            var result = Converter.RGBImageToBitmap(rgbResult);

            return result;
        }

        public Bitmap ChangeContrast(Bitmap image, float contrast)
        {
            Bitmap result = null;

            if(contrast>0)
            {
                float min;
                float max;

                var hsvImage = Converter.BitmapToHSVImage(image);
                ContrastRangeSelection.ContrastStretchingRangeSelection(new IntensityHistogram(Flatten2DArrayHelper.Flatten2DArray(hsvImage.Value)), out min, out max);

                float actualMin = (contrast / 100) * min;
                float actualMax = 1 - ((contrast / 100) * (1 - max));

                var hsvResult = ContrastStretchingAlgorithm.StretchContrast(hsvImage, actualMin, actualMax);

                result = Converter.HSVImageToBitmap(hsvResult);
            }
            else if(contrast<0)
            {
                contrast *= -1;

                var hsvImage = Converter.BitmapToHSVImage(image);
                var histogram = new IntensityHistogram(Flatten2DArrayHelper.Flatten2DArray(hsvImage.Value));

                var maximumDiffrence = (histogram.X.Max() - histogram.X.Min()) * 0.05;

                float min = (float) (histogram.X.Min() + (maximumDiffrence * (contrast/100)));
                float max = (float) (histogram.X.Max() - (maximumDiffrence * (contrast/100)));

                var hsvResult = ContrastShrinkingAlgorithm.ShrinkContrast(hsvImage, min, max);
                result = Converter.HSVImageToBitmap(hsvResult);
            }

            return result;
        }
    }
}
