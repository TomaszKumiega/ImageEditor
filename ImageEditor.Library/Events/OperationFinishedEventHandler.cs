using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Library.Events
{
    public class OperationFinishedEventArgs : EventArgs
    {
        public string OperationName { get; }

        public OperationFinishedEventArgs(string operationName)
        {
            OperationName = operationName;
        }
    }

    public delegate void OperationFinishedEventHandler(object sender, OperationFinishedEventArgs args);
}
