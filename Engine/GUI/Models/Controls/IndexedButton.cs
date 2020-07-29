using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.GUI.Models
{
    public class IndexedButton : Button
    {
        private bool active;

        public IndexedButton(Vector vector, string text, int size, Action<PixControl> taskToRepresent, int index) : base(vector, text, size, taskToRepresent)
        {
            Index = index;
        }

        public int Index { get; }
        public bool Active 
        { 
            get => active; 
            set 
            { 
                active = value;
                color = value ? new Color(140, 200, 230) : new Color(0, 0, 0);
            } 
        }
    }
}