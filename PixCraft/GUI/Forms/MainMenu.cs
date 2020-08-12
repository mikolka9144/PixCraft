using Engine.GUI.Models;
using Engine.Logic;
using Integration;
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

        public MainMenu(IMouse mouse, Engine.IDrawer drawer) :base(new Color(0,100,100),300,null,mouse,drawer)
        {
            var options = new Box[] { new Box("Start", SwichToNewWorldForm), new Box("Load World", SwichToLoadWorldForm) };

            controls.Add(new Label(new Vector(0, 80), "PixCraft", 200,drawer,mouse));
            controls.Add(new Label(new Vector(90, -90), "V.2.0", 20, drawer, mouse));
            //if (DebuggerAttached()) controls.Add(new Label(new Vector(-90, -90), "DEBUG :>", 20));
            optionsWindow = new SelectBox(new Vector(0, 0), options, drawer, mouse);
            controls.Add(optionsWindow);
        }

        private void SwichToLoadWorldForm()
        {
            var form = new LoadWorldForm(this);
            SwichTo(form);
        }
    }
}
