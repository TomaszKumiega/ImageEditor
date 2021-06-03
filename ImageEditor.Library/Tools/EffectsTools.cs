using ImageEditor.Library.Algorithms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageEditor.Library.Tools
{
    public class EffectsTools : IEffectsTools
    {
        private INegativeAlgorithm NegativeAlgorithm { get; }
        private IGrayscaleAlgorithm GrayscaleAlgorithm { get; }
        private ISharpeningAlgorithm SharpeningAlgorithm { get; }

        public EffectsTools(INegativeAlgorithm negativeAlgorithm, IGrayscaleAlgorithm grayscaleAlgorithm)
        {
            NegativeAlgorithm = negativeAlgorithm;
            GrayscaleAlgorithm = grayscaleAlgorithm;
        }

        public Bitmap ChangeToGrayScale(Bitmap bitmap)
        {
            return GrayscaleAlgorithm.ChangeToGrayscale(bitmap);
        }

        public Bitmap ChangeToNegative(Bitmap bitmap)
        {
            return NegativeAlgorithm.ChangeToNegative(bitmap);
        }

        public Bitmap Sharpen(Bitmap bitmap, float strength)
        {
            var scaledStrength = strength / 100;
            return SharpeningAlgorithm.Sharpen(bitmap, scaledStrength);
        }
    }
}
