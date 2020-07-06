
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Logic
{
    public class CraftingModule
    {
        private PlayerStatus inventory;
        private readonly List<CraftingEntry> craftingEntries;

        public CraftingModule(PlayerStatus inventory,List<CraftingEntry> craftingEntries)
        {
            this.inventory = inventory;
            this.craftingEntries = craftingEntries;
        }

        public bool Craft(BlockType blockType)
        {
            var craft = craftingEntries.Find(s => s.CraftedItem.type == blockType);
            foreach (var item in craft.NeededItems)
            {
                if (item.Count > inventory.Inventory.FindAll(s => s.type == item.type).Select(s => s.Count).Sum()) return false;
            }

            foreach (var item in craft.NeededItems)
            {
                var requiredCount = craft.NeededItems.First(s => s.type == item.type).Count;
                var materil = inventory.Inventory.FindAll(s => s.type == item.type);
                if(materil.First().Count < requiredCount)
                {
                    requiredCount -= materil.First().Count;
                    inventory.Inventory.Remove(materil.First());
                    
                }
                inventory.Decrement(item.type,requiredCount);                
            }
            inventory.AddElement(craft.CraftedItem);
            return true;
        }
    }
}