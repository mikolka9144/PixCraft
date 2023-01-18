using Engine.Engine;
using Engine.Logic;
using Integration;
using System;

namespace Engine.GUI.Models.Controls
{
    class CloseButton : Button
    {
        public CloseButton(Vector2 vector, int size, Action<PixControl> closeAction,IDrawer drawer,IMouse mouse) : base(vector, " ", size, closeAction,drawer,mouse)
        {
            image = 55;
            color = new Color(255, 0, 0);
        }
    }
}
