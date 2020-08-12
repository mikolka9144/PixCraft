using Engine.Resources;

namespace Engine.Engine.models
{
    public class OreEntry
    {

        public OreEntry(int minimumDepth, int howOftenGenerateBits, int oresPerXBlocks, BlockType type, bool isFluid = false)
        {
            MinimumDepth = minimumDepth;
            ChanceOfSpawn = howOftenGenerateBits;
            OresPerXBlocks = oresPerXBlocks;
            Type = type;
            IsFluid = isFluid;
        }

        public bool IsFluid { get; }
        public int MinimumDepth { get; }
        public int ChanceOfSpawn { get; }
        public int OresPerXBlocks { get; }
        public BlockType Type { get; }
    }
}