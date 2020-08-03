using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;

namespace Engine.GUI
{
    internal class NewWorldForm : Form
    {
        private SelectBox parameters;

        public NewWorldForm(Form previousForm) : base(new Color(200, 100, 0), 300,previousForm)
        {
            IList<Box> PreBoxs = new Box[] 
            { 
                new Box("0", StaticExtensions.configureAsTextBox(true)), 
                new Box("0", StaticExtensions.configureAsTextBox(true)),
                new Box("Generate", GenerateWorld) 
            };
            controls.Add(new Label(new Vector(-30, 20), "size", 20));
            controls.Add(new Label(new Vector(-30, -10), "seed", 20));
            parameters = new SelectBox(new Vector(0, 20), PreBoxs);
            controls.Add(parameters);
        }

        private void GenerateWorld()
        {
            Hide();
            var seed = int.Parse(parameters.ItemsList[1].label.text);
            var size = int.Parse(parameters.ItemsList[0].label.text);
            StartUp.InitGame(size, seed);
        }
    }
}