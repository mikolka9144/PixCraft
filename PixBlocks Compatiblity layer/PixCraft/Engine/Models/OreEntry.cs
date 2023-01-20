using Engine.Resources;

namespace Engine.Engine.models
{
    public class OreEntry
    {

        public OreEntry(int minimumDepth, int howOftenGenerateBits, int oresPerXBlocks, BlockType type)
        {
            MinimumDepth = minimumDepth;
            ChanceOfSpawn = howOftenGenerateBits;
            OresPerXBlocks = oresPerXBlocks;
            Type = type;
        }

        public bool IsFluid { get; }
        public int MinimumDepth { get; }
        public int ChanceOfSpawn { get; }
        public int OresPerXBlocks { get; }
        public BlockType Type { get; }
    }
}