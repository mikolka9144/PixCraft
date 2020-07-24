using Engine.Engine;
using Engine.GUI.Models;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;

namespace Engine.GUI
{
    class NewWorldForm : Form
    {
        private SelectBox parameters;

        public NewWorldForm() : base(new Color(200,100,0), 300)
        {
            controls.Add(new Label(new Vector(-30, 20), "size", 20));
            controls.Add(new Label(new Vector(-30, -10), "seed", 20));

            IList<Box> PreBoxs = new Box[] { new Box("0",ChangeSize), new Box("0", ChangeSeed) ,new Box("Generate",GenerateWorld)};
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

        private void ChangeSeed()
        {
            parameters.ItemsList[1].label.text = TryParseInput(parameters.ItemsList[1].label.text);
        }

        private string TryParseInput(string PrevValue)
        {
            var input = GameScene.gameSceneStatic.PythonCodeRunner.show("Enter Value");
            var isNumeric = int.TryParse(input, out _);
            return isNumeric ? input : PrevValue;
        }

        private void ChangeSize()
        {
            parameters.ItemsList[0].label.text = TryParseInput(parameters.ItemsList[0].label.text);
        }
    }
}
