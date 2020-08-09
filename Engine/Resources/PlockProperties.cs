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
            if(Items.Contains(type)||type == BlockType.None ) return new BlockProperties(true, false);
            switch (type)
            {
                case BlockType.WoodPixaxe:
                    return new BlockProperties(false, false, ToolType.Pixaxe, 10, 30);
                case BlockType.WoodAxe:
                    return new BlockProperties(false, false, ToolType.Axe, 10, 30);
                case BlockType.WoodShovel:
                    return new BlockProperties(false, false, ToolType.Shovel, 10, 30);
            }
            return new BlockProperties(true, true);
        }
    }
}

namespace Engine
{
    public struct BlockProperties
    {
        public ToolType type;
        public int power;
        public int durablity;
        public bool CanStack;
        public bool IsPlaceAble;

        public BlockProperties(bool IsStackable, bool IsPlaceable)
        {
            CanStack = IsStackable;
            IsPlaceAble = IsPlaceable;
            power = 1;
            type = ToolType.None;
            durablity = 0;
            
        }
        public BlockProperties(bool IsStackable, bool IsPlaceable,ToolType type,int Power,int Durablity):this(IsStackable,IsPlaceable)
        {
            this.type = type;
            power = Power;
            durablity = Durablity;
        }
    }

    public enum ToolType
    {
        None,
        Axe,
        Shovel,
        Pixaxe,
        Sword
    }
}