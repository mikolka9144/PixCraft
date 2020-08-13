using Engine.GUI.Models;
using Engine.Logic;
using Integration;

namespace Engine.GUI
{
    internal class LoadWorldForm:Form
    {
        private StartUp init;
        private Button txtFile;

        public LoadWorldForm(Form previousForm, Integration.IMouse mouse, Engine.IDrawer drawer,IGameScene scene,StartUp init) :base(new Color(100,200,255),300,previousForm,mouse,drawer)
        {
            controls.Add(new Label(new Vector2(0, 40), "Enter path to file", 50,drawer,mouse));
            txtFile = new Button(new Vector2(0, 0), " ", 50, StaticExtensions.configureAsTextBox(false,scene), drawer, mouse);
            controls.Add(new Button(new Vector2(0, -50), "Load Save", 50, LoadSave, drawer, mouse));
            controls.Add(txtFile);
            this.init = init;
        }

        private void LoadSave(PixControl _)
        {
            Hide();
            init.InitGame(txtFile.label.text);
        }
    }
}