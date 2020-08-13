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

        public List<Block> Blocks { get; } = new List<Block>();

        public List<Foliage> Toppings { get; } = new List<Foliage>();

        
        public List<Fluid> Fluids { get; } = new List<Fluid>();
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
            var x = Parameters.BlockSize;
            var block = new Block(BlockX * x, BlockY * x, Id, drawer, processor);
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
            drawer.remove(tile);
            drawer.remove(tile.foliage);
            Blocks.Remove(tile);
            Toppings.Remove(tile.foliage);
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

        public bool AddFluid(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false, bool Draw = false)
        {
            var x = Parameters.BlockSize;
            var currentBlock = Blocks.Find(s => (s.position.x / x) == BlockX && s.position.y / x == BlockY);
            if (currentBlock != null)
            {
                if (replace)
                {

                    Blocks.Remove(currentBlock);
                    Toppings.Remove(currentBlock.foliage);
                }
                else
                {
                    return false;
                }
            }
            else if (forceReplace)
            {
                return false;
            }
            AddFluid(new Fluid(BlockX * x, BlockY * x, Id, drawer, processor));
            return true;
        }
        public void RemoveFluid(Fluid fluid)
        {
            Fluids.Remove(fluid);
            drawer.remove(fluid);
        }

        public void AddFluid(Fluid block) => Fluids.Add(block);

        
        public List<Block> GetActiveBlocks(Vector2 sprite)
        {
            return Blocks.FindAll(s => s.IsInRange(parameters.hitboxArea, sprite)).ToList();
        }
        public List<Foliage> GetActiveToppings(Vector2 sprite)
        {
            return Toppings.FindAll(s => s.IsInRange(parameters.hitboxArea, sprite)).ToList();
        }


        public List<Fluid> GetActiveFluids(Vector2 sprite)
        {
            return Fluids.FindAll(s => s.IsInRange(parameters.hitboxArea,sprite)).ToList();
        }
    }
}