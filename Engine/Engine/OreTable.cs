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
            OreSeparator = 30;
            Entries = new List<OreEntry>();
            this.InitOreTable();
        }

        public int OreSeparator { get; }
        public List<OreEntry> Entries { get; }

        public int GetChance(BlockType type) => Entries.Find(s => s.Type == type).ChanceOfSpawn;

        public int GetCount(BlockType type, int worldsize)
        {
            var oresPerX = Entries.Find(s => s.Type == type).OresPerXBlocks;
            var getMultiplayer = worldsize / OreSeparator;
            return oresPerX * getMultiplayer;
        }

        public int GetMinimumDepth(BlockType type) => Entries.Find(s => s.Type == type).MinimumDepth;

    }
}
