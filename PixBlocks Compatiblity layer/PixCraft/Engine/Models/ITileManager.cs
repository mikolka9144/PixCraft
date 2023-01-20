using Engine.Logic.models;
using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Engine.models
{
    public interface ITileManager:IActiveElements
    {
        World World { get; }
        List<LEDBlockTile> LEDBlocks { get; }

        ///<summary>
        ///Creates a block with collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false);

        ///<summary>
        ///Creates a block without collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id);

        void RemoveTile(LEDBlockTile tile);

    }
}