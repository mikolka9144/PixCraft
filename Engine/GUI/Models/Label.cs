using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI.Models
{
    class Label:PixControl
    {
        public Label(Vector vector,string message,int size)
        {
            position = vector;
            this.size = size;
            text = message;
        }
    }
}
