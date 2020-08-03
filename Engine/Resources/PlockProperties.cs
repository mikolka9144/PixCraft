using System.Collections.Generic;

namespace Engine.Resources
{
    public static class BlockPropertiesData
    {
        private static List<BlockType> Items = new List<BlockType>() 
        {
            BlockType.GoldBar,
            BlockType.IronBar,
            BlockType.stick,
        };
        public static BlockProperties GetProperties(BlockType type)
        {
            if(Items.Contains(type) ) return new BlockProperties(true, false);
            return new BlockProperties(true, true);
        }
    }
}

namespace Engine
{
    public struct BlockProperties
    {
        public bool CanStack;
        public bool IsPlaceAble;

        public BlockProperties(bool IsStackable, bool IsPlaceable)
        {
            CanStack = IsStackable;
            IsPlaceAble = IsPlaceable;
        }
    }
}