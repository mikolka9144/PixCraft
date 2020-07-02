﻿using Engine.Engine.models;
using Engine.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine
{
    public class TileManager : IActiveElements, ITileManager
    {
        public List<Block> ActiveBlocks => Blocks.FindAll(s => s.IsActiveBlock()).ToList();
        public List<Block> Blocks { get; } = new List<Block>();

        public List<Foliage> Toppings { get; } = new List<Foliage>();
        public List<Foliage> ActiveToppings => Toppings.FindAll(s => s.IsActiveBlock()).ToList();

        private readonly Parameters parameters;
        private readonly IDrawer drawer;
        private readonly IIdProcessor processor;

        public TileManager(Parameters parameters, IDrawer drawer, IIdProcessor processor)
        {
            this.parameters = parameters;
            this.drawer = drawer;
            this.processor = processor;
        }



        public void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false)
        {
            var x = parameters.BlockSize;
            var currentBlock = Blocks.Find(s => (s.X / x) == BlockX && s.Y / x == BlockY);
            if (currentBlock != null)
            {
                if (replace)
                {
                    Blocks.Remove(currentBlock);
                    Toppings.Remove(currentBlock.foliage);
                }
                else
                {
                    return;
                }
            }
            else if (forceReplace)
            {
                return;
            }

            AddBlockTile(BlockX, BlockY, Id, Draw);
        }

        public void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool Draw = false)
        {
            var x = parameters.BlockSize;
            var block = new Block(BlockX * x, BlockY * x, Id, x, drawer, processor, parameters);
            AddBlockTile(block, Draw);
        }
        public void AddBlockTile(Block block, bool ShouldDraw)
        {
            Blocks.Add(block);
            Toppings.Add(block.foliage);
            if (ShouldDraw)
            {
                drawer.Draw(block);
                drawer.Draw(block.foliage);
            }
        }
        public void RemoveTile(Block tile)
        {
            drawer.remove(tile.Sprite);
            drawer.remove(tile.foliage.Sprite);
            this.Blocks.Remove(tile);
            this.Toppings.Remove(tile.foliage);
        }
    }
}
