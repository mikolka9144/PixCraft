using Engine.Logic;
using System.Collections.Generic;

namespace Engine.Resources
{
    internal static class Craftings
    {
        internal static List<CraftingEntry> GetCraftings()
        {
            var list = new List<CraftingEntry>();

            #region CraftingsData

            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Wood) }, new Item(4, BlockType.Planks)));
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Planks) }, new Item(4, BlockType.stick)));

            #endregion CraftingsData

            return list;
        }
    }
}