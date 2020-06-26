using System;

namespace Engine.Engine
{
    internal class Generator
    {
        private Random randomizer;
        private int CanGenerateTree;
        
        private readonly ITileManager manager;
        private readonly Parameters parameters;

        public Generator(int seed, ITileManager manager,Parameters paramters)
        {
            randomizer = new Random(seed);
            this.manager = manager;
            parameters = paramters;
            CanGenerateTree = parameters.TreeSpread;
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
                manager.AddBlockTile(parameters.BlockSize * BlockX, parameters.BlockSize * BlockY, BlockType.Grass, parameters.BlockSize, false);
                if (randomizer.Next(0,parameters.treeChance) == 0 && random >= parameters.minimumFillarHeightForTree && CanGenerateTree == 3) generateTree(BlockX, BlockY);
                else if (CanGenerateTree != parameters.TreeSpread) CanGenerateTree++;
            }
            else
            {

                manager.AddBlockTile(parameters.BlockSize * BlockX, parameters.BlockSize * BlockY, BlockType.Dirt, parameters.BlockSize, false);
            }
        }

        private void generateTree(int X, int Y)
        {
            for (int i = Y+1; i < Y+4; i++)
            {
                manager.AddBlockTile(parameters.BlockSize * X, parameters.BlockSize * i, BlockType.Wood, parameters.BlockSize, false);
            }
            manager.AddBlockTile(parameters.BlockSize * X, parameters.BlockSize * (Y+4), BlockType.Leaves, parameters.BlockSize, false);
            manager.AddBlockTile(parameters.BlockSize * (X-1), parameters.BlockSize * (Y+3), BlockType.Leaves, parameters.BlockSize, false);
            manager.AddBlockTile(parameters.BlockSize * (X+1), parameters.BlockSize * (Y +3), BlockType.Leaves, parameters.BlockSize, false);
            CanGenerateTree = 0;
        }

        public void CreateUnderGround(int size)
        {
            for (int i = -size; i < 0; i++)
            {
                GenerateCollumnOfStone(i * parameters.BlockSize);
            }

            for (int i = 0; i < size; i++)
            {
                GenerateCollumnOfStone(i * parameters.BlockSize);
            }
        }

        private void GenerateCollumnOfStone(int X)
        {
            for (int i = -1; i > -parameters.sizeOfStoneCollumn; i--)
            {
                manager.AddBlockTile(X, i * parameters.BlockSize, BlockType.Stone, parameters.BlockSize, false);
            }
        }
    }
}