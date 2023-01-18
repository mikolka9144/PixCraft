using Engine.Engine;
using Engine.Logic;
using Integration;
using System;

namespace Engine.GUI.Models
{
    public class Button:PixControl
    {
        public Button(Vector2 vector,string text,int size,Action<PixControl> taskToRepresent,IDrawer drawer,IMouse mouse):base(drawer,mouse)
        {
            label = new Label(vector, text, size,drawer,mouse);
            label.color = new Color(100, 100, 100);

            position = vector;
            this.size = size;
            OnClick = taskToRepresent;
            image = 77;
            angle = 90;
        }
        public override void Show()
        {
            base.Show();
            label.Show();
        }
        public override void Hide()
        {
            base.Hide();  
            label.Hide();
        }
        

        public Label label { get; }
        public Action<Button> TaskToRepresent { get; set; }
    }
}
