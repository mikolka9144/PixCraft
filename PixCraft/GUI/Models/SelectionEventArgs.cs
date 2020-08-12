using System;

namespace Engine.GUI.Models
{
    public class SelectionEventArgs:EventArgs
    {
        public IndexedButton radio;

        public SelectionEventArgs(IndexedButton radio)
        {
            this.radio = radio;
        }
    }
}