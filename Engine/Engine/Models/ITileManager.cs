﻿using Engine.Resources;
using System.Collections.Generic;

namespace Engine.Engine.models
{
    public interface ITileManager
    {
        List<Block> Blocks { get; }
        List<Foliage> Toppings { get; }
        List<Fluid> Fluids { get; }
        void RemoveFluid(Fluid fluid);
        void AddBlockTile(Block block, bool ShouldDraw);
        void AddFluid(Fluid block);

        ///<summary>
        ///Creates a block with collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false);
        void AddFluid(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false);

        ///<summary>
        ///Creates a block without collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool Draw = false);

        void RemoveTile(Block tile);

        void PlaceBlock(int x, int y, BlockType blockType);
    }
}