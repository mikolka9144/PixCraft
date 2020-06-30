using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Parameters
    {
        public (int Up,int Left,int Right,int Down) border = (100,100,100,100);
        public (int Up,int Left,int Right,int Down) hitboxArea = (20,20,20,20);
        public int Delay = 0;
        //Generator Parameters
        public int BlockSize = 20;
        public int sizeOfStoneCollumn = 20;

        public int TreeSpread = 3;
        public int minimumFillarHeightForTree = 3;
        public int treeChance = 5;
        public int moveSpeed = 5;
        public int MaxFallSpeed = 6;
        //Gameplay
        public int BlocksCollisionDelay = 2;
        public int MoveDelay = 3;
        public int ChunkSize = 20;
        public int breakingRange = 50;
        internal int BaseHealth = 20;
        internal int MaxSlotCapatility = 64;
        internal int minimumBlocksForFall = 3;
        internal int PointerRange = 80;
    }

}
