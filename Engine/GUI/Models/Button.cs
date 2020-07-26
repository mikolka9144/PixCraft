using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.PythonIron.Tools.Game;
using System;

namespace Engine.GUI.Models
{
    public class Button:PixControl
    {
        public Button(Vector vector,string text,int size,Action<PixControl> taskToRepresent)
        {
            label = new Label(vector, text, size);
            label.color = new Color(100, 100, 100);

            position = vector;
            this.size = size;
            OnClick += taskToRepresent;
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
