using System;

namespace Engine.Engine
{
    internal class Generator
    {
        private Random randomizer;
        private int CanGenerateTree = 3;
        private const int BlockSize = 20;
        private readonly ITileManager manager;
        private const int sizeOfCollumn = 10;
        public Generator(int seed, ITileManager manager)
        {
            randomizer = new Random(seed);
            this.manager = manager;
        }
        // Token: 0x06000015 RID: 21 RVA: 0x000024C0 File Offset: 0x000006C0
        public void GenerateTerrian(int blocks)
        {
            for (int i = -blocks; i < 0; i++)
            {
                var random = randomizer.Next(1, 5);
                for (int j = 0; j < random; j++)
                {
                    GenerateFillarOfDirt(j, i, random);
                    
                }
            }
            //reverse
            for (int k = 0; k < blocks; k++)
            {
                var random = randomizer.Next(1, 5);
                for (int l = 0; l < random; l++)
                {
                    GenerateFillarOfDirt(l, k,random);
                }
            }

        }

        private void GenerateFillarOfDirt(int BlockY, int BlockX, int random)
        {
            if (random - 1 == BlockY)
            {
                manager.AddBlockTile(BlockSize * BlockX, BlockSize * BlockY, BlockType.Grass, BlockSize, false);
                if (randomizer.Next(0, 4) == 3 && random >= 3 && CanGenerateTree == 3) generateTree(BlockX, BlockY);
                else if (CanGenerateTree != 3) CanGenerateTree++;
            }
            else
            {

                manager.AddBlockTile(20 * BlockX, BlockSize * BlockY, BlockType.Dirt, 20, false);
            }
        }

        private void generateTree(int X, int Y)
        {
            for (int i = Y+1; i < Y+4; i++)
            {
                manager.AddBlockTile(20 * X, 20 * i, BlockType.Wood, 20, false);
            }
            manager.AddBlockTile(BlockSize * X, BlockSize * (Y+4), BlockType.Leaves, BlockSize, false);
            manager.AddBlockTile(BlockSize * (X-1), BlockSize * (Y+3), BlockType.Leaves, BlockSize, false);
            manager.AddBlockTile(BlockSize * (X+1), BlockSize * (Y +3), BlockType.Leaves, BlockSize, false);
            CanGenerateTree = 0;
        }

        public void CreateUnderGround(int size)
        {
            for (int i = -size; i < 0; i++)
            {
                GenerateCollumnOfStone(i * BlockSize);
            }

            for (int i = 0; i < size; i++)
            {
                GenerateCollumnOfStone(i * BlockSize);
            }
        }

        private void GenerateCollumnOfStone(int X)
        {
            for (int i = -1; i > -sizeOfCollumn; i--)
            {
                manager.AddBlockTile(X, i * BlockSize, BlockType.Stone, BlockSize, false);
            }
        }
    }
}