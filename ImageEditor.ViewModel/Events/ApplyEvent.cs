using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.ViewModel.Events
{
    public class ApplyEventArgs
    {
        public Operation Operation { get; }

        public ApplyEventArgs(Operation op)
        {
            Operation = op;
        }
    }
        

    public delegate void ApplyEventHandler(object sender, ApplyEventArgs args);
}
