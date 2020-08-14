using Engine.GUI.Models;
using Engine.Logic;
using Engine.Saves;
using Integration;

namespace Engine.GUI
{
    class PauseForm : Form
    {
        private SelectBox selectBox;
        private readonly Engine.Engine engine;
        private readonly SaveManager manager;
        private SaveWorldForm SaveForm;

        public PauseForm(Engine.Engine engine,SaveManager manager, Integration.IMouse mouse, Engine.IDrawer drawer,IGameScene scene) : base(new Color(204, 153, 51), 150,null,mouse,drawer)
        {
            var list = new Box[] { new Box("Resume", Resume), new Box("Save", Save) };
            selectBox = new SelectBox(new Vector2(0, 20), list,drawer,mouse);
            controls.Add(selectBox);
            this.engine = engine;
            this.manager = manager;
            SaveForm = new SaveWorldForm(manager,this,mouse,drawer,scene);
        }

        public override void Show()
        {
            engine.Stop();
            base.Show();
        }
        private void Save()
        {
            Hide();
            SaveForm.Show();
        }

        private void Resume()
        {
            engine.Start();
            Hide();
        }
    }
}
