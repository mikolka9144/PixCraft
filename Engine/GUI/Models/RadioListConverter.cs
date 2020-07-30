using Engine.Logic;
using System.Collections.Generic;

namespace Engine.GUI.Models
{
    static class RadioListConverter
    {
        public static void Initalize(this RadioList radioList,List<Item> items)
        {
            var elements = new List<RadioTemplate>();
            foreach (var item in items)
            {
                elements.Add(new RadioTemplate($"{item.Name} X:{item.Count}"));
            }
            radioList.Initalize(elements);
        }
    }
}
