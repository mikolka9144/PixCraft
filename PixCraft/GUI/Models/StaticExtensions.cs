using Integration;
using System;

namespace Engine.GUI.Models
{
    public static class StaticExtensions
    {
        public static Action<PixControl> configureAsTextBox(bool IsNumber,IGameScene scene)
        {
            return (s) => Task(s, IsNumber,scene);
        }

        private static void Task(PixControl item, bool IsNumber, IGameScene scene)
        {
            var button = item as Button;
            button.label.text = TryParseInput(button.label.text, IsNumber,scene);
        }

        private static string TryParseInput(string PrevValue, bool IsNumber,IGameScene scene)
        {
            var input = scene.GetInput("Enter Value");
            var isNumeric = int.TryParse(input, out _);
            return isNumeric || !IsNumber ? input : PrevValue;
        }
    }
}