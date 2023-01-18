using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Logic
{
    public class CraftingEntry
    {
        public CraftingEntry(IEnumerable<Item> neededItems, Item craftedItem,BlockType station)
        {
            NeededItems = neededItems;
            CraftedItem = craftedItem;
            Station = station;
        }

        public IEnumerable<Item> NeededItems { get; }
        public Item CraftedItem { get; }
        public BlockType Station { get; }
        public override string ToString() => CraftedItem.ToString();
        
    }
}