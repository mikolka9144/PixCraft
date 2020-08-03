using Engine.GUI.Models;
using Engine.Saves;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI
{
    class PauseForm : Form
    {
        private SelectBox selectBox;
        private readonly Engine.Engine engine;
        private readonly SaveManager manager;

        public PauseForm(Engine.Engine engine,SaveManager manager) : base(new Color(204, 153, 51), 150,null)
        {
            var list = new Box[] { new Box("Resume", Resume), new Box("Save", Save) };
            selectBox = new SelectBox(new Vector(0, 20), list);
            controls.Add(selectBox);
            this.engine = engine;
            this.manager = manager;
        }

        public override void Show()
        {
            engine.Sprites.ForEach(s => s.Active = false);
            base.Show();
        }
        private void Save()
        {
            var form = new SaveWorldForm(manager,this);
            Hide();
            form.Show();
        }

        private void Resume()
        {
            engine.Sprites.ForEach(s => s.Active = true);
            Hide();
        }
    }
}
