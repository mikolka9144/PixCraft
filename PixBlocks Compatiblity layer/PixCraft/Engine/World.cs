using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Diagnostics;
using Engine.Engine.models;
using Engine.Resources;

namespace Engine.Engine
{
    public class World
    {
        private HashSet<BlockData> baseWorld = new HashSet<BlockData>(new BlockDataCompare());

        /// Gets block at specifyed position or returns null if absent
        public BlockData GetBlock(int blockX, int blockY)
        {
            //! make better implementation
            var block = baseWorld.FirstOrDefault(s => s.X == blockX && s.Y == blockY);
            if(block == null) return new BlockData(blockX,blockY,BlockType.None);
            else return block;
        }
        public List<BlockData> GetAllThat(Func<BlockData,bool> predicate){
            return baseWorld.Where(predicate).ToList();
        }
        public bool SetBlock(int BlockX,int BlockY,BlockType type){
            return baseWorld.Add(new BlockData(BlockX,BlockY,type));
        }
        public bool SetBlock(BlockData block){
            return baseWorld.Add(block);
        }
        public void RemoveBlock(BlockData block){
            baseWorld.Remove(block);
        }
        private class BlockDataCompare : IEqualityComparer<BlockData>
        {
            public bool Equals(BlockData x, BlockData y)
            {
                return x.X == y.X && x.Y == x.Y;
            }

            public int GetHashCode(BlockData obj)
            {
                return obj.X.GetHashCode()+obj.Y.GetHashCode();
            }
        }
    }
    
}


