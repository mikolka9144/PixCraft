using System;
using System.Collections.Generic;

namespace Engine.Logic
{
    public class PlayerStatus
    {
        private int MaxSlotLimit;

        public int health { get; set; }
        public List<Item> Inventory { get; private set; }
        public IStatusDisplayer Displayer { get; }
        internal void LoadState(int health, List<Item> Inventory)
        {
            this.health = health;
            this.Inventory = Inventory;
        }
        public PlayerStatus(IStatusDisplayer displayer)
        {
            health = Parameters.BaseHealth;
            Inventory = new List<Item>();
            Displayer = displayer;
            MaxSlotLimit = Parameters.MaxSlotCapatility;
        }
        public void AddElement(Item item)
        {
            var clones = Inventory.FindAll(s => s.Compare(item));
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
            if (!selection.IsPlaceable) return BlockType.None;
            Decrement(selection.type,1);
            return selection.type;
        }
        public void OpenInventory() => Displayer.Present(health, this);
        public void Decrement(BlockType selection,int count)
        {
            var allItemsOfKind = Inventory.FindAll(s => s.type == selection);
            for (int i = 0; i < allItemsOfKind.Count; i++)
            {

                if (allItemsOfKind[i].Count - count <= 0)
                {
                    Inventory.Remove(allItemsOfKind[i]);
                    count -= allItemsOfKind[i].Count;
                }
                else allItemsOfKind[i].Count -= count;
            }

            
        }
        public bool DealDamage(int DistanceFallen)
        {
            if (DistanceFallen >= Parameters.minimumBlocksForFall*Parameters.BlockSize)
            {
                DistanceFallen -= Parameters.minimumBlocksForFall* Parameters.BlockSize;
                health -= DistanceFallen / Parameters.BlockSize;
                if (health <= 0) OnKill.Invoke();
                return true;
            }
            return false;
        }

        internal event Action OnKill;
    }
}
