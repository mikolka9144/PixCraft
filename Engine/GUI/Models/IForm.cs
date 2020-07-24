using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;

namespace Engine.GUI
{
    public class Form:PixControl
    {
        public Form(Color color,int size)
        {
            this.size = size;
            image = 63;
            this.color = color;
        }
        public List<PixControl> controls = new List<PixControl>();
        public override void Show()
        {
            base.Show();
            controls.ForEach(s => s.Show());
        }
        public override void Hide()
        {
            base.Hide();
            controls.ForEach(s => s.Hide());
        }

    }
}