using System.Collections.Generic;
using System.Windows.Forms;

namespace Engine.GUI
{
    internal static class ItemsConverter
    {
        public static ListViewItem[] LoadItemsToList(List<Logic.Item> inventory)
        {
            var list = new List<ListViewItem>();
            for (int i = 0; i < inventory.Count; i++)
            {
                var elementToTransform = inventory[i];
                var ViewItem = new ListViewItem($"{elementToTransform.Name} x{elementToTransform.Count}")
                {
                    Tag = i
                };
                list.Add(ViewItem);
            }
            return list.ToArray();
        }
    }
}