using Engine.Engine.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine
{
    public class TileManager : ITileManager
    {
        private readonly Parameters parameters;
        private readonly IDrawer drawer;
        private readonly IIdProcessor processor;

        public TileManager(Parameters parameters, IDrawer drawer, IIdProcessor processor)
        {
            this.parameters = parameters;
            this.drawer = drawer;
            this.processor = processor;
        }
        public List<Block> Blocks { get; }  = new List<Block>();

        

        public void AddBlockTile(int BlockX, int BlockY, BlockType Id, bool replace, bool forceReplace = false)
        {
            var x = parameters.BlockSize;
            var currentBlock = Blocks.Find(s => (s.X / x) == BlockX && s.Y / x == BlockY);
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
            else if(forceReplace)
            {
                return;            
            }
            Blocks.Add(new Block(BlockX * x, BlockY * x, Id, x, drawer, processor));
        }
    }
}
