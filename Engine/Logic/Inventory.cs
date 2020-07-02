using System;

namespace Engine.Logic
{
    [Serializable]
    public class Item
    {
        public Item(bool CanStack,int count,BlockType type)
        {
            this.CanStack = CanStack;
            Count = count;
            Type = type;
        }

        public bool CanStack { get; }
        public int Count { get; set; }
        public BlockType Type { get; }
    }
}