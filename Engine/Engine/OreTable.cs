using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Resources;
using System.Threading.Tasks;
using Engine.Engine.models;

namespace Engine.Engine
{
    public partial class OreTable : IOreTable
    {
        public OreTable(IEnumerable<OreEntry> oreEntries)
        {
            Entries = new List<OreEntry>();
            Entries.AddRange(oreEntries);
        }

        public List<OreEntry> Entries { get; }

        public int GetChance(BlockType type) => Entries.Find(s => s.Type == type).ChanceOfSpawn;

        public int GetCount(BlockType type)
        {
            var oresPerX = Entries.Find(s => s.Type == type).OresPerXBlocks;
            return oresPerX;
        }

        public int GetMinimumDepth(BlockType type) => Entries.Find(s => s.Type == type).MinimumDepth;

    }
}
