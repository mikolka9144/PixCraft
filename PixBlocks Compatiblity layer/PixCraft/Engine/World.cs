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
        private List<BlockData> baseWorld = new List<BlockData>();

        /// Gets block at specifyed position or returns null if absent
        public BlockData GetBlock(int blockX, int blockY)
        {
            //! make better implementation
            var block = baseWorld.FirstOrDefault(s => s.X == blockX && s.Y == blockY);
            if(block == null) return new BlockData(blockX,blockY,BlockType.None);
            else return block;
        }
        public List<BlockData> GetAllThat(Predicate<BlockData> predicate){
            return baseWorld.FindAll(predicate);
        }
        public void SetBlock(int BlockX,int BlockY,BlockType type){
            baseWorld.Add(new BlockData(BlockX,BlockY,type));
        }
        public void SetBlock(BlockData block){
            baseWorld.Add(block);
        }
        public void RemoveBlock(BlockData block){
            baseWorld.Remove(block);
        }
    }
}


