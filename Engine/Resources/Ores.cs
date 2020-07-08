using Engine.Engine.models;

namespace Engine.Resources
{
    public static class OreResource
    {
        public static OreEntry[] InitOreTable()
        {
            var list = new OreEntry[]
            {
                new OreEntry(1,3,4,BlockType.CoalOre),
                new OreEntry(1,4,3,BlockType.IronOre),
                new OreEntry(10,5,2,BlockType.GoldOre),
                new OreEntry(15,6,1,BlockType.DiamondOre)
            };
            return list;
        }
    }
}