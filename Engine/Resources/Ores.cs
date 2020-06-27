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
        public static void InitOreTable(this OreTable table)
        {
            var list = new OreEntry[]
            {
                new OreEntry(2,6,10,BlockType.Dirt),
                new OreEntry(4,4,10,BlockType.Leaves),
                new OreEntry(18,2,10,BlockType.Wood)
            };
            table.Entries.AddRange(list);
        }
    }
}
