using Engine.Logic;
using Integration;
using System;

namespace Engine.GUI.Models
{
    public class IndexedButton : Button
    {

        public IndexedButton(Vector vector, object objectToRepresent, int size, Action<PixControl> taskToRepresent, Engine.IDrawer drawer, IMouse mouse) : base(vector, objectToRepresent.ToString(), size, taskToRepresent,drawer,mouse)
        {
            ObjectToRepresent = objectToRepresent;
        }

        public object ObjectToRepresent { get; }

        private bool active;
        public bool Active 
        { 
            get => active; 
            set 
            { 
                active = value;
                color = value ? new Color(140, 200, 230) : new Color(15, 142, 255);
            } 
        }
    }
}