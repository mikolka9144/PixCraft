using System.Collections.Generic;

namespace Engine.Logic
{
    public class CraftingEntry
    {
        public CraftingEntry(IEnumerable<Item> neededItems,Item craftedItem)
        {
            NeededItems = neededItems;
            CraftedItem = craftedItem;
        }

        public IEnumerable<Item> NeededItems { get; }
        public Item CraftedItem { get; }
    }
}