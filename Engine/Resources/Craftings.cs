using Engine.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Resources
{
    static class Craftings
    {
        internal static List<CraftingEntry> GetCraftings()
        {
            var list = new List<CraftingEntry>();
            #region CraftingsData
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Wood) }, new Item(4, BlockType.Planks)));
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Planks) }, new Item(4, BlockType.stick)));
            #endregion

            return list;
        }
    }
}
