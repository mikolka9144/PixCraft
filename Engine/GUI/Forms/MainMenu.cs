using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Integration;
using Label = Engine.GUI.Models.Label;

namespace Engine.GUI
{
    public class MainMenu:Form
    {

        private  void SwichToNewWorldForm()
        {
            var form = new NewWorldForm(this);
            SwichTo(form);
        }

        private void SwichTo(Form form)
        {
            Hide();
            form.Show();
        }

        private SelectBox optionsWindow;

        public MainMenu():base(new Color(0,100,100),300,null)
        {
            var options = new Box[] { new Box("Start", SwichToNewWorldForm), new Box("Load World", SwichToLoadWorldForm) };

            controls.Add(new Label(new Vector(0, 80), "PixCraft", 200));
            controls.Add(new Label(new Vector(90, -90), "V.1.0", 10));
            optionsWindow = new SelectBox(new Vector(0, 0), options);
            controls.Add(optionsWindow);
        }

        private void SwichToLoadWorldForm()
        {
            var form = new LoadWorldForm(this);
            SwichTo(form);
        }
    }
}
