using Engine.GUI.Models;
using Engine.Logic;
using Engine.Saves;
using Integration;

namespace Engine.GUI
{
    internal class SaveWorldForm:Form
    {
        private readonly SaveManager manager;
        private Button txtFile;

        public SaveWorldForm(SaveManager manager,Form PrevForm, IMouse mouse, Engine.IDrawer drawer,IGameScene scene) :base(new Color(200,100,0),300,PrevForm,mouse,drawer)
        {
            controls.Add(new Label(new Vector(0, 40), "Enter path to file", 50,drawer,mouse));
            txtFile = new Button(new Vector(0, 0), " ", 50, StaticExtensions.configureAsTextBox(false,scene), drawer, mouse);
            controls.Add(new Button(new Vector(0, -50), "Save world", 50, SaveSave, drawer, mouse));
            controls.Add(txtFile);
            this.manager = manager;
        }

        private void SaveSave(PixControl _)
        {
            manager.SaveToFile(txtFile.label.text);
            Close();
        }
        public override void Show()
        {
            base.Show();
        }
    }
}