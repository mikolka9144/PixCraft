using PixBlocks.PythonIron.Tools.Game;
using System;

namespace Engine.GUI.Models
{
    public static class StaticExtensions
    {
        public static Action<BoxItem> configureAsTextBox(bool IsNumber)
        {
            return (s) => Task(s, IsNumber);
        }

        private static void Task(BoxItem item, bool IsNumber)
        {
            item.label.text = TryParseInput(item.label.text, IsNumber);
        }

        private static string TryParseInput(string PrevValue, bool IsNumber)
        {
            var input = GameScene.gameSceneStatic.PythonCodeRunner.show("Enter Value");
            var isNumeric = int.TryParse(input, out _);
            return isNumeric || !IsNumber ? input : PrevValue;
        }
    }
}