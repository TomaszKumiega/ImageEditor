using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public interface IFlatten2DArrayHelper<T>
    {
        T[] Flatten2DArray(T[,] array);
    }
}
