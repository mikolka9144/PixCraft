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
                case BlockType.WoodSword:
                    return new BlockProperties(false, false, ToolType.Sword, 3, 30);

                case BlockType.IronPixaxe:
                    return new BlockProperties(false, false, ToolType.Pixaxe, 20, 80);
                case BlockType.IronAxe:
                    return new BlockProperties(false, false, ToolType.Axe, 20, 60);
                case BlockType.IronShovel:
                    return new BlockProperties(false, false, ToolType.Shovel, 20, 50);
                case BlockType.IronSword:
                    return new BlockProperties(false, false, ToolType.Sword, 8, 30);

                case BlockType.StonePixaxe:
                    return new BlockProperties(false, false, ToolType.Pixaxe, 15, 30);
                case BlockType.StoneAxe:
                    return new BlockProperties(false, false, ToolType.Axe, 15, 30);
                case BlockType.StoneShovel:
                    return new BlockProperties(false, false, ToolType.Shovel, 15, 30);
                case BlockType.StoneSword:
                    return new BlockProperties(false, false, ToolType.Sword, 6, 30);

                case BlockType.GoldPixaxe:
                    return new BlockProperties(false, false, ToolType.Pixaxe, 10, 20);
                case BlockType.GoldAxe:
                    return new BlockProperties(false, false, ToolType.Axe, 10, 20);
                case BlockType.GoldShovel:
                    return new BlockProperties(false, false, ToolType.Shovel, 10, 20);
                case BlockType.GoldSword:
                    return new BlockProperties(false, false, ToolType.Sword, 5, 20);

                case BlockType.DiamondPixaxe:
                    return new BlockProperties(false, false, ToolType.Pixaxe, 25, 500);
                case BlockType.DiamondAxe:
                    return new BlockProperties(false, false, ToolType.Axe, 25, 500);
                case BlockType.DiamondShovel:
                    return new BlockProperties(false, false, ToolType.Shovel, 25, 500);
                case BlockType.DiamondSword:
                    return new BlockProperties(false, false, ToolType.Sword, 25, 120);
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