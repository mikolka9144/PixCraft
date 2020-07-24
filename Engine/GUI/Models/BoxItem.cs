using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.PythonIron.Tools.Game;
using System;

namespace Engine.GUI.Models
{
    class BoxItem:PixControl
    {
        public BoxItem(Vector vector,string text,int size,Action taskToRepresent)
        {
            label = new Label(vector, text, size);
            label.color = new Color(100, 100, 100);

            position = vector;
            this.size = size;
            TaskToRepresent = taskToRepresent;
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
        public override void update()
        {
            if (collide(GameScene.gameSceneStatic.mouse.position) && GameScene.gameSceneStatic.mouse.pressed) TaskToRepresent.Invoke();
        }

        private bool collide(Vector position)
        {
            if (!IsVisible) return false;
            double mouseSize = 10;
            double num = size * 0.5 + mouseSize * 0.5;
            if (Math.Abs(position.x - this.position.x) > num || Math.Abs(position.y - this.position.y) > num)
            {
                return false;
            }
            if (Math.Sqrt((position.x - this.position.x) * (position.x - this.position.x) + (position.y - this.position.y) * (position.y - this.position.y)) < num)
            {
                return true;
            }
            return false;
        }

        public Label label { get; }
        public Action TaskToRepresent { get; }
    }
}
