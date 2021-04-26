using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Helpers
{
    public class Flatten2DArrayHelper<T> : IFlatten2DArrayHelper<T>
    {
        public T[] Flatten2DArray(T[,] array)
        {
            var length = array.Length;

            var result = new T[length];

            var k = 0;

            for (int x = 0; x < array.GetLength(0); x++)
            {
                for (int y = 0; y < array.GetLength(1); y++)
                {
                    result[k] = array[x, y];
                    k++;
                }
            }

            return result;
        }
    }
}
