using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine.GUI
{
    static class ItemsConverter
    {
        public static ListViewItem[] LoadItemsToList(List<Logic.Item> inventory)
        {
            var list = new List<ListViewItem>();
            for (int i = 0; i < inventory.Count; i++)
            {
                var elementToTransform = inventory[i];
                var ViewItem = new ListViewItem($"{elementToTransform.Name} x{elementToTransform.Count}");
                ViewItem.Tag = i;
                list.Add(ViewItem);
            }
            return list.ToArray();
        }
    }
}
