namespace Engine.Engine
{
    public interface IGeneratorParameters
    {
        int TreeSpread { get; }
        int minimumFillarHeightForTree { get; }
        int treeChance { get; }
        int WaterLevel { get; }
        int sizeOfStoneCollumn { get; }
        int ChunkSize { get; }
    }
}