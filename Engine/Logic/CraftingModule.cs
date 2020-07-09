﻿using Engine.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Logic
{
    public class CraftingModule
    {
        private readonly List<CraftingEntry> _craftingEntries;
        public List<CraftingEntry> craftingEntries 
        {
            get
            {
                var listToReturn = new List<CraftingEntry>();
                foreach (var craft in _craftingEntries)
                {
                    if (NearbyBlockCheck.IsStationNearby(craft.Station)) listToReturn.Add(craft);
                }
                return listToReturn;
            }
        }

        public CraftingModule(List<CraftingEntry> craftingEntries,INearbyBlockCheck nearbyBlockCheck)
        {
            _craftingEntries = craftingEntries;
            NearbyBlockCheck = nearbyBlockCheck;
        }

        public INearbyBlockCheck NearbyBlockCheck { get; }

        public bool Craft(PlayerStatus inventory, BlockType blockType)
        {
            var craft = _craftingEntries.Find(s => s.CraftedItem.type == blockType);

            foreach (var item in craft.NeededItems)
            {
                if (item.Count > inventory.Inventory.FindAll(s => s.type == item.type).Select(s => s.Count).Sum()) return false;
            }

            foreach (var item in craft.NeededItems)
            {
                var requiredCount = craft.NeededItems.First(s => s.type == item.type).Count;
                var materil = inventory.Inventory.FindAll(s => s.type == item.type);
                if (materil.First().Count < requiredCount)
                {
                    requiredCount -= materil.First().Count;
                    inventory.Inventory.Remove(materil.First());
                }
                inventory.Decrement(item.type, requiredCount);
            }
            inventory.AddElement(craft.CraftedItem);
            return true;
        }
    }
}