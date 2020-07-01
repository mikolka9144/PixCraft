using System;
using System.Collections.Generic;

namespace Engine.Logic
{
    public class PlayerStatus
    {
        private int MaxSlotLimit;
        private readonly Parameters parameters;

        public int health { get; set; }
        public List<Item> Inventory { get; private set; }
        public IStatusDisplayer Displayer { get; }
        internal void LoadState(int health, List<Item> Inventory)
        {
            this.health = health;
            this.Inventory = Inventory;
        }
        public PlayerStatus(Parameters parameters,IStatusDisplayer displayer)
        {
            health = parameters.BaseHealth;
            Inventory = new List<Item>();
            this.parameters = parameters;
            Displayer = displayer;
            MaxSlotLimit = parameters.MaxSlotCapatility;
        }
        public void AddElement(Item item)
        {
            var clones = Inventory.FindAll(s => s.Type == item.Type);
            if (clones is null || !item.CanStack)
            {
                Inventory.Add(item);

            }
            else
            {
                foreach (var element in clones)
                {
                    if (element.Count + item.Count <= MaxSlotLimit)
                    {
                        element.Count += item.Count;
                        return;
                    }
                }
                    Inventory.Add(item);                
            }
        }
        public BlockType GetBlockToPlace()
        {
            var index = Displayer.SelectedIndex;
            if (index < 0 || Inventory.Count -1<index) return BlockType.None;
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
        public bool DealDamage(int DistanceFallen)
        {
            if (DistanceFallen >= parameters.minimumBlocksForFall*parameters.BlockSize)
            {
                DistanceFallen -= parameters.minimumBlocksForFall* parameters.BlockSize;
                health -= DistanceFallen / parameters.BlockSize;
                if (health <= 0) OnKill.Invoke();
                return true;
            }
            return false;
        }

        internal event Action OnKill;
    }
}
