using Engine.Engine.models;
using System.Collections.Generic;

namespace Engine.Engine
{
    public interface ITileManager
    {
        List<Block> Blocks { get; }
        List<Foliage> Toppings { get; }

        void AddBlockTile(Block block, bool ShouldDraw);
        ///<summary>
        ///Creates a block with collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false);
        ///<summary>
        ///Creates a block without collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool Draw = false);
        void RemoveTile(Block tile);
    }
}