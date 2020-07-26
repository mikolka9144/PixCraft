using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI.Models
{
    internal class RadioEntry : PixControl
    {
        private Label label;

        public bool Active
        {
            get => _active;
            set
            {
                _active = value;
                image = value ? 58 : 56;
            }
        }

        private bool _active;

        public RadioEntry(Vector vector, string text)
        {
            label = new Label(new Vector(vector.x + 10, vector.y), text, 30);
        }
        public override void update()
        {
            base.update();
        }
        public override void Show()
        {
            label.Show();
            base.Show();
        }

        public override void Hide()
        {
            label.Hide();
            base.Hide();
        }
    }
}