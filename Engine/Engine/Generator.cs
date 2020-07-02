using System;

namespace Engine.Engine
{
    internal class Generator
    {
        private Random randomizer;
        private int CanGenerateTree;
        
        private readonly ITileManager manager;
        private readonly Parameters parameters;
        private readonly IOreTable oreTable;
        private readonly int size;

        public Generator(int seed, ITileManager manager,Parameters paramters,IOreTable oreTable,int size)
        {
            randomizer = new Random(seed);
            this.manager = manager;
            parameters = paramters;
            this.oreTable = oreTable;
            this.size = size;
            CanGenerateTree = parameters.TreeSpread;
        }
        // Token: 0x06000015 RID: 21 RVA: 0x000024C0 File Offset: 0x000006C0
        public void GenerateTerrian()
        {
            for (int i = -size; i < 0; i++)
            {
                var random = randomizer.Next(1, 5);
                for (int j = 0; j < random; j++)
                {
                    GenerateFillarOfDirt(j, i, random);
                    
                }
            }
            //reverse
            for (int k = 0; k < size; k++)
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
                manager.AddBlockTile(BlockX,BlockY, BlockType.Grass);
            }
            else
            {

                manager.AddBlockTile(BlockX,BlockY, BlockType.Dirt);
            }
        }

        internal void Render()
        {
            foreach (var item in manager.Blocks)
            {
                manager.AddBlockTile(item, true);
            }
        }

        public void GenerateTrees()
        {
            foreach (var item in manager.Blocks.FindAll(s => s.Id == BlockType.Grass))
            {
                var size = parameters.BlockSize;
                var ranSel = randomizer.Next(0, parameters.treeChance) == 0;
                var HasSize = item.Y >= parameters.minimumFillarHeightForTree*parameters.BlockSize;
                var IsAwayFromTrees = CanGenerateTree == 3;

                if(ranSel&&HasSize&&IsAwayFromTrees) generateTree(item.X/size, item.Y/size);
                else if (CanGenerateTree != parameters.TreeSpread) CanGenerateTree++;
            }
        }
        private void generateTree(int X, int Y)
        {
            for (int i = Y+1; i < Y+4; i++)
            {
                manager.AddBlockTile(X,i, BlockType.Wood,false);
            }
            manager.AddBlockTile(X, (Y+4), BlockType.Leaves, false);
            manager.AddBlockTile((X-1),(Y+3), BlockType.Leaves, false);
            manager.AddBlockTile((X+1),(Y +3), BlockType.Leaves, false);
            CanGenerateTree = 0;
        }

        public void CreateUnderGround()
        {
            for (int X = -size; X < 0; X++)
            {
                GenerateCollumnOfStone(X);
            }

            for (int X = 0; X < size; X++)
            {
                GenerateCollumnOfStone(X);
            }
        }

        private void GenerateCollumnOfStone(int X)
        {
            for (int Y = -1; Y > -parameters.sizeOfStoneCollumn; Y--)
            {
                manager.AddBlockTile(X, Y, BlockType.Stone);
            }
        }
        public void GenerateOres(BlockType type)
        {
            var offset = parameters.ChunkSize;
            var count = oreTable.GetCount(type);
            var pointer = -size;
            var chunks = size*2/offset;
            if (size % 10 != 0) chunks++;
            for (int c = 0; c < chunks; c++)
            {
                for (int i = 0; i < count; i++)
                {
                    var X = randomizer.Next(pointer, pointer + offset);
                    var Y = randomizer.Next(-parameters.sizeOfStoneCollumn, -oreTable.GetMinimumDepth(type));
                    GenerateOre(X, Y, type, oreTable.GetChance(type));
                }
                pointer += offset;
            }
        }
        private void GenerateOre(int X, int Y,BlockType type,int bitSpawnChance)
        {
            manager.AddBlockTile(X, Y, type, true, true);
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    GenerateBit(X-x, Y-y, type, bitSpawnChance);
                }
            }
        }
        private void GenerateBit(int X, int Y, BlockType type,int spawnChance)
        {
            if (randomizer.Next(0, spawnChance) == 0) manager.AddBlockTile(X, Y, type, true, true);
        }
    }
}