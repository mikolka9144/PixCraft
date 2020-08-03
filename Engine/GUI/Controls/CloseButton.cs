using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.GUI.Models.Controls
{
    class CloseButton : Button
    {
        public CloseButton(Vector vector, int size, Action<PixControl> closeAction) : base(vector, " ", size, closeAction)
        {
            image = 55;
            color = new Color(255, 0, 0);
        }
    }
}
