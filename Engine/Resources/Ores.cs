using Engine.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

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
