using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic
{
    internal class PlayerStatus
    {
        private int MaxSlotLimit;

        public int health { get; private set; }
        public List<Item> Inventory { get; }
        public IStatusDisplayer Displayer { get; }

        public PlayerStatus(Parameters parameters,IStatusDisplayer displayer)
        {
            health = parameters.BaseHealth;
            Inventory = new List<Item>();
            Displayer = displayer;
            MaxSlotLimit = parameters.MaxSlotCapatility;
        }
        public void AddElement(Item item)
        {
            var clone = Inventory.Find(s => s.Type == item.Type);
            if (clone is null || !item.CanStack)
            {
                Inventory.Add(item);

            }
            else
            {
                if (clone.Count + item.Count <= MaxSlotLimit)
                {
                    clone.Count += item.Count;
                }
                else
                {
                    Inventory.Add(item);
                }
            }
        }
        public BlockType GetBlockToPlace()
        {
            var index = Displayer.SelectedIndex;
            if (index < 0 || Inventory.Count == 0) return BlockType.None;
            var selection = Inventory[index];
            Decrement(selection);
            return selection.Type;
        }
        public void OpenInventory() => Displayer.Present(health, Inventory);
        private void Decrement(Item selection)
        {
            selection.Count -= 1;
            if (selection.Count <= 0) Inventory.Remove(selection);
        }
    }
}
