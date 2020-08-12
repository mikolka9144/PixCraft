using Engine.Logic;

namespace Engine.GUI.Models
{
    public class Label:PixControl
    {
        public Label(Vector vector,string message,int size, Engine.IDrawer drawer, Integration.IMouse mouse) :base(drawer,mouse)
        {
            position = vector;
            this.size = size;
            text = message;
        }

        
    }
}
