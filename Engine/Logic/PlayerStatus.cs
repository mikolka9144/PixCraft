using Engine.Logic.models;
using Engine.Resources;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class PlayerStatus
    {
        public int health { get; set; }
        public int breath { get; set; }
        public List<Item> Inventory { get; private set; }
        public IStatusDisplayer Displayer { get; }
        public Action OnDamageDeal;
        private Task lavaDamageDeal;

        private void LavaDamage()
        {
            Deal(Parameters.LavaDamage);
            Thread.Sleep(1000);
        }

        internal void LoadState(int health, List<Item> Inventory)
        {
            this.health = health;
            this.Inventory = Inventory;
        }

        public PlayerStatus(IStatusDisplayer displayer)
        {
            breath = Parameters.MaxBreath;
            health = Parameters.BaseHealth;
            Inventory = new List<Item>();
            Displayer = displayer;
            lavaDamageDeal = new Task(LavaDamage);
        }

        public void AddElement(Item item)
        {
            var clones = Inventory.FindAll(s => s.Compare(item));
            if (clones is null)
            {
                Inventory.Add(item);
            }
            else if (!item.CanStack)
            {
                for (int i = 0; i < item.Count; i++)
                {
                    Inventory.Add(new Item(1, item.type));
                }
            }
            else
            {
                foreach (var element in clones)
                {
                    if (element.Count + item.Count <= Parameters.MaxSlotCapatility)
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
            if (index < 0 || Inventory.Count - 1 < index) return BlockType.None;
            var selection = Inventory[index];
            if (!selection.IsPlaceable) return BlockType.None;
            Decrement(selection.type, 1);
            return selection.type;
        }

        public void DealBreathBuuble()
        {
            breath--;
            if (breath < 0) Deal(1);
        }

        internal void DealDamageFromLava()
        {
            if (lavaDamageDeal.Status == TaskStatus.RanToCompletion || lavaDamageDeal.Status == TaskStatus.Created)
            {
                lavaDamageDeal = new Task(LavaDamage);
                lavaDamageDeal.Start();
            }
        }

        private void Deal(int v)
        {
            if (health <= v) OnKill();
            health -= v;
            OnDamageDeal();
        }

        internal void RestoreBreath()
        {
            breath = Parameters.MaxBreath;
        }

        public void OpenInventory() => Displayer.Present( this);

        public void Decrement(BlockType selection, int count)
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

        public void DealDamage(int DistanceFallen)
        {
            if (DistanceFallen >= Parameters.minimumBlocksForFall * Parameters.BlockSize)
            {
                DistanceFallen -= Parameters.minimumBlocksForFall * Parameters.BlockSize;
                Deal(DistanceFallen / Parameters.BlockSize);
                
            }
        }
        internal Action OnKill;
    }
}