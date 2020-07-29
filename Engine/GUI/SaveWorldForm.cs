using Engine.GUI.Models;
using Engine.Saves;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;

namespace Engine.GUI
{
    internal class SaveWorldForm:Form
    {
        private readonly SaveManager manager;
        private readonly Form prevForm;
        private Button txtFile;

        public SaveWorldForm(SaveManager manager,Form PrevForm):base(new Color(200,100,0),300)
        {
            controls.Add(new Label(new Vector(0, 40), "Enter path to file", 50));
            txtFile = new Button(new Vector(0, 0), " ", 50, StaticExtensions.configureAsTextBox(false));
            controls.Add(new Button(new Vector(0, -50), "Save world", 50, SaveSave));
            controls.Add(txtFile);
            this.manager = manager;
            prevForm = PrevForm;
        }

        private void SaveSave(PixControl _)
        {
            manager.SaveToFile(txtFile.label.text);
            Hide();
            Thread.Sleep(100);
            prevForm.Show();
        }
        public override void Show()
        {
            Thread.Sleep(100);
            base.Show();
        }
    }
}