using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Resources
{
    public static class BlockProperties
    {
        public static (bool CanStack,bool IsPlaceAble) GetProperties(BlockType type)
        {
            switch (type)
            {
                case BlockType.Grass:
                    return (true,true);
                case BlockType.Dirt:
                    return (true, true);
                case BlockType.Stone:
                    return (true, true);
                case BlockType.Wood:
                    return (true, true);
                case BlockType.Leaves:
                    return (true, true);
                case BlockType.CoalOre:
                    return (true, true);
                case BlockType.IronOre:
                    return (true, true);
                case BlockType.GoldOre:
                    return (true, true);
                case BlockType.DiamondOre:
                    return (true, true);
                case BlockType.Planks:
                    return (true, true);
            }
            return (true, false);
        }
    }
}
