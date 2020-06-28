using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Resources;
using System.Threading.Tasks;

namespace Engine.Engine
{
    public partial class OreTable : IOreTable
    {
        public OreTable()
        {
            Entries = new List<OreEntry>();
            this.InitOreTable();
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
