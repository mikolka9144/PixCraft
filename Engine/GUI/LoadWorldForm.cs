using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI
{
    internal class LoadWorldForm:Form
    {
        private BoxItem txtFile;

        public LoadWorldForm() :base(new Color(100,200,255),300)
        {
            controls.Add(new Label(new Vector(0, 40), "Enter path to file", 50));
            txtFile = new BoxItem(new Vector(0, 0), " ", 50, StaticExtensions.configureAsTextBox(false));
            controls.Add(new BoxItem(new Vector(0, -50), "Load Save", 50, LoadSave));
            controls.Add(txtFile);
        }

        private void LoadSave(BoxItem _)
        {
            Hide();
            StartUp.InitGame(txtFile.label.text);
        }
    }
}