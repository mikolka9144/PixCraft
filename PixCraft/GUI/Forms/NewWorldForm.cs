using Engine.Engine;
using Engine.GUI.Models;
using Engine.Logic;
using Integration;
using System.Collections.Generic;

namespace Engine.GUI
{
    internal class NewWorldForm : Form
    {
        private readonly StartUp init;
        private SelectBox parameters;

        public NewWorldForm(Form previousForm,StartUp init, IMouse mouse, IDrawer drawer,IGameScene scene) : base(new Color(200, 100, 0), 300,previousForm,mouse,drawer)
        {
            IList<Box> PreBoxs = new Box[] 
            { 
                new Box("0", StaticExtensions.configureAsTextBox(true,scene)), 
                new Box("0", StaticExtensions.configureAsTextBox(true,scene)),
                new Box("Generate", GenerateWorld) 
            };
            controls.Add(new Label(new Vector(-30, 20), "size", 20,drawer,mouse));
            controls.Add(new Label(new Vector(-30, -10), "seed", 20, drawer, mouse));
            parameters = new SelectBox(new Vector(0, 20), PreBoxs, drawer, mouse);
            controls.Add(parameters);
            this.init = init;
        }

        private void GenerateWorld()
        {
            Hide();
            var seed = int.Parse(parameters.ItemsList[1].label.text);
            var size = int.Parse(parameters.ItemsList[0].label.text);
            init.InitGame(size, seed);
        }
    }
}