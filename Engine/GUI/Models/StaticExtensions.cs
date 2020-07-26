using PixBlocks.PythonIron.Tools.Game;
using System;

namespace Engine.GUI.Models
{
    public static class StaticExtensions
    {
        public static Action<PixControl> configureAsTextBox(bool IsNumber)
        {
            return (s) => Task(s, IsNumber);
        }

        private static void Task(PixControl item, bool IsNumber)
        {
            var button = item as Button;
            button.label.text = TryParseInput(button.label.text, IsNumber);
        }

        private static string TryParseInput(string PrevValue, bool IsNumber)
        {
            var input = GameScene.gameSceneStatic.PythonCodeRunner.show("Enter Value");
            var isNumeric = int.TryParse(input, out _);
            return isNumeric || !IsNumber ? input : PrevValue;
        }
    }
}