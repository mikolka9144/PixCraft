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
            SwichTo(NewWorldForm);
        }

        private void SwichTo(Form form)
        {
            Hide();
            form.Show();
        }

        private SelectBox optionsWindow;

        internal LoadWorldForm LoadWorldform { get; }
        internal NewWorldForm NewWorldForm { get; }

        public MainMenu(IMouse mouse, Engine.IDrawer drawer,IGameScene scene,StartUp init) :base(new Color(0,100,100),300,null,mouse,drawer)
        {
            var options = new Box[] { new Box("Start", SwichToNewWorldForm), new Box("Load World", SwichToLoadWorldForm) };

            controls.Add(new Label(new Vector2(0, 80), "PixCraft", 200,drawer,mouse));
            controls.Add(new Label(new Vector2(90, -90), "V.2.1", 20, drawer, mouse));
            optionsWindow = new SelectBox(new Vector2(0, 0), options, drawer, mouse);
            controls.Add(optionsWindow);
            LoadWorldform = new LoadWorldForm(this,mouse,drawer,scene,init);
            NewWorldForm = new NewWorldForm(this,init, mouse, drawer, scene);
        }

        private void SwichToLoadWorldForm()
        {
            SwichTo(LoadWorldform);
        }
    }
}
