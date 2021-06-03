using System.Drawing;

namespace ImageEditor.Library.Algorithms
{
    public interface ISharpeningAlgorithm
    {
        Bitmap Sharpen(Bitmap image, double strength);
    }
}