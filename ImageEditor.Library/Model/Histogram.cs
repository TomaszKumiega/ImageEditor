﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Model
{
    public class Histogram<T> : SortedDictionary<T, int>
    {
        public Histogram()
        {

        }

        public Histogram(T[,] array)
        {
            InitializeHistogram(array);
        }

        private void InitializeHistogram(T[,] array)
        {
            foreach(var t in array)
            {
                if(ContainsKey(t))
                {
                    this[t]++;
                }
                else
                {
                    Add(t, 1);
                }
            }
        }

        public int CountAll()
        {
            int all = 0;

            foreach(var t in this)
            {
                all += t.Value;
            }

            return all;
        }
    }
}
