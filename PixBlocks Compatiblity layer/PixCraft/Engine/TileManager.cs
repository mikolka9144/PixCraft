using Engine.Engine.models;
using Engine.Logic;
using Engine.Logic.models;
using Engine.Resources;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Engine
{
    public class TileManager :ITileManager,INearbyBlockCheck
    {
        public List<Block> VisiableBlocks => Blocks.FindAll(s =>s.IsVisible).ToList();

        public List<List<Block>> Blocks { get; } = new List<List<Block>>();

        
        public List<Block>
        public ITileManagerParameters parameters { get; }

        private readonly IDrawer drawer;
        private readonly IIdProcessor processor;

        public TileManager(IDrawer drawer, IIdProcessor processor,ITileManagerParameters parameters)
        {
            this.drawer = drawer;
            this.processor = processor;
            this.parameters = parameters;
        }

        public void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false)
        {
            int x = Parameters.BlockSize;
            var currentBlock = Blocks.Find(s => (s.position.x / x) == BlockX && s.position.y / x == BlockY);
            if (currentBlock != null)
            {
                if (replace)
                {
                    
                    Blocks.Remove(currentBlock);
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
            var x = Parameters.BlockSize;
            var block = new Block(BlockX * x, BlockY * x, Id, drawer, processor);
            AddBlockTile(block, Draw);
        }

        public void AddBlockTile(Block block, bool ShouldDraw)
        {
            Blocks
            if (ShouldDraw)
            {
                drawer.Draw(block);
            }
        }

        public void RemoveTile(Block tile)
        {
            drawer.remove(tile);
            Blocks.Remove(tile);
        }

        public void PlaceBlock(int x, int y, BlockType blockType)
        {
            var block = new Block(x, y, blockType, drawer, processor);
            AddBlockTile(block, true);
        }

        public bool IsStationNearby(BlockType station)
        {
            if (station == BlockType.None) return true;
            return GetActiveBlocks(new Vector2(0,0)).Any(s => s.Id == station);
        }

        
        
        public List<Block> GetActiveBlocks(Vector2 sprite)
        {
            return Blocks.FindAll(s => s.IsInRange(parameters.hitboxArea, sprite) && s.position.y > parameters.blockTypeBorder + sprite.y);
        }
        public List<Block> GetActiveToppings(Vector2 sprite)
        {
            return Blocks.FindAll(s => s.IsInRange(parameters.hitboxArea, sprite) && s.position.y <= parameters.blockTypeBorder+sprite.y);
        }


        public List<Fluid> GetActiveFluids(Vector2 sprite)
        {
            return Fluids.FindAll(s => s.IsInRange(parameters.hitboxArea,sprite)).ToList();
        }

        public void AddFluid(int x, int y, BlockType type)
        {
            int size = Parameters.BlockSize;
            AddFluid(new Fluid(x * size, y * size, type, drawer, processor));
        }
    }
}