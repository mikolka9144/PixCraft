using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Integration;
using System.Threading;
using Label = Engine.GUI.Models.Label;

namespace Engine.GUI
{
    public class MainMenu:Form
    {

        private  void SwichToNewWorldForm()
        {
            Hide();
            var form = new NewWorldForm();
            Thread.Sleep(50);
            form.Show();
        }

        private SelectBox optionsWindow;

        public MainMenu():base(new Color(0,200,100),300)
        {
            var options = new Box[] { new Box("Start", SwichToNewWorldForm), new Box("Load World", null) };

            controls.Add(new Label(new Vector(0, 80), "PixCraft", 50));
            optionsWindow = new SelectBox(new Vector(0, 0), options);
            controls.Add(optionsWindow);
        }
    }
}
