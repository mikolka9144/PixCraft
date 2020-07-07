using Engine.Resources;

namespace Engine.Engine.models
{
    public interface IOreTable
    {
        int GetChance(BlockType type);
        int GetCount(BlockType type);
        int GetMinimumDepth(BlockType type);
    }
}