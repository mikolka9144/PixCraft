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

            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Wood) }, new Item(4, BlockType.Planks),BlockType.None));
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Planks) }, new Item(4, BlockType.stick),BlockType.None));
            list.Add(new CraftingEntry(new Item[] { new Item(4, BlockType.Planks) }, new Item(1, BlockType.CraftingTable),BlockType.None));

            list.Add(new CraftingEntry(new Item[] { new Item(8, BlockType.Stone) }, new Item(1, BlockType.Furnance),BlockType.CraftingTable));
            list.Add(new CraftingEntry(new Item[] { new Item(3, BlockType.Planks), new Item(2, BlockType.stick) }, new Item(1, BlockType.WoodPixaxe),BlockType.CraftingTable));
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.Planks),new Item(2, BlockType.stick) }, new Item(1, BlockType.WoodShovel),BlockType.CraftingTable));
            list.Add(new CraftingEntry(new Item[] { new Item(3, BlockType.Planks),new Item(2, BlockType.stick) }, new Item(1, BlockType.WoodAxe),BlockType.CraftingTable));

            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.IronOre),new Item(1,BlockType.Planks) }, new Item(1, BlockType.IronBar),BlockType.Furnance));
            list.Add(new CraftingEntry(new Item[] { new Item(1, BlockType.GoldBar), new Item(1, BlockType.Planks) }, new Item(1, BlockType.GoldBar),BlockType.Furnance));

            #endregion CraftingsData

            return list;
        }
    }
}