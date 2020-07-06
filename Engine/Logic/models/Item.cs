using Engine.Resources;
using System;

namespace Engine.Logic
{
    public class Item
    {
        public Item(int count,BlockType type)
        {
            var Properties = BlockProperties.GetProperties(type);
            this.CanStack = Properties.CanStack;
            IsPlaceable = Properties.IsPlaceAble;
            Count = count;
            this.type = type;
        }
        public Item()
        {

        }

        public bool CanStack { get; set; }
        public bool IsPlaceable { get; set; }
        public int Count { get; set; }
        public BlockType type { get; set; }
        public string Name { get => type.ToString();}

        public bool Compare(Item item)
        {
            return item.type == type;
        }
    }
}