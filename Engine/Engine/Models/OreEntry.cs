namespace Engine.Engine
{
    public class OreEntry
    {
        public OreEntry(int minimumDepth, int chanceOfSpawn,int oresPerXBlocks, BlockType type)
        {
            MinimumDepth = minimumDepth;
            ChanceOfSpawn = chanceOfSpawn;
            OresPerXBlocks = oresPerXBlocks;
            Type = type;
        }

        public int MinimumDepth { get; }
        public int ChanceOfSpawn { get; }
        public int OresPerXBlocks { get; }
        public BlockType Type { get; }
    }
    
}