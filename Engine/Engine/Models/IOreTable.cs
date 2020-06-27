namespace Engine.Engine
{
    public interface IOreTable
    {
        int GetChance(BlockType type);
        int GetCount(BlockType type,int worldSize);
        int GetMinimumDepth(BlockType type);
    }
}