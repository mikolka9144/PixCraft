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
        public IPlayerStatusParameters parameters { get; }

        public Action OnDamageDeal;
        private Task lavaDamageDeal;

        private void LavaDamage()
        {
            Deal(parameters.LavaDamage);
            Thread.Sleep(1000);
        }

        internal void LoadState(int health, List<Item> Inventory)
        {
            this.health = health;
            this.Inventory = Inventory;
        }

        public PlayerStatus(IStatusDisplayer displayer,IPlayerStatusParameters parameters)
        {
            breath = parameters.MaxBreath;
            health = parameters.BaseHealth;
            Inventory = new List<Item>();
            Displayer = displayer;
            this.parameters = parameters;
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
                    Inventory.Add(new Item(1, item.Type));
                }
            }
            else
            {
                foreach (var element in clones)
                {
                    if (element.Count + item.Count <= parameters.MaxSlotCapatility)
                    {
                        element.Count += item.Count;
                        return;
                    }
                }
                Inventory.Add(item);
            }
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

        public Item GetItem()
        {
            var index = Displayer.SelectedIndex;
            if (index < 0 || Inventory.Count - 1 < index) return new Item(1,BlockType.None);
            var selection = Inventory[index];
            //Decrement(selection.type, 1);
            return selection;
        }

        private void Deal(int v)
        {
            if (health <= v) OnKill();
            health -= v;
            OnDamageDeal();
        }

        internal void RestoreBreath()
        {
            breath = parameters.MaxBreath;
        }

        public void OpenInventory() => Displayer.Present( this);

        public void Decrement(BlockType selection, int count)
        {
            var allItemsOfKind = Inventory.FindAll(s => s.Type == selection);
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
            if (DistanceFallen >= parameters.minimumBlocksForFall * Parameters.BlockSize)
            {
                DistanceFallen -= parameters.minimumBlocksForFall * Parameters.BlockSize;
                Deal(DistanceFallen / Parameters.BlockSize);
                
            }
        }
        internal Action OnKill;
    }
}