namespace Engine.Resources
{
    public static class BlockPropertiesData
    {
        public static BlockProperties GetProperties(BlockType type)
        {
            if(type >0 ) return new BlockProperties(true, true);
            return new BlockProperties(true, false);
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