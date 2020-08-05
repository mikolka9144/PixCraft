using Engine.Engine.models;
using Engine.Resources;
using System;

namespace Engine.Engine
{
    internal class Generator
    {
        private Random randomizer;
        private int CanGenerateTree;

        private readonly ITileManager manager;
        private readonly IOreTable oreTable;
        private int size;
        private readonly IDrawer drawer;

        public Generator(ITileManager manager, IOreTable oreTable,IDrawer drawer)
        {
            
            this.manager = manager;
            this.oreTable = oreTable;
            this.drawer = drawer;
            CanGenerateTree = Parameters.TreeSpread;
        }

        public void GenerateWorld(int seed,int size)
        {
            randomizer = new Random(seed);
            this.size = size;

            GenerateTerrian();
            GenerateWater();
            GenerateTrees();
            CreateUnderGround();
            GenerateOres(BlockType.CoalOre);
            GenerateOres(BlockType.IronOre);
            GenerateOres(BlockType.GoldOre);
            GenerateOres(BlockType.DiamondOre);
            GenerateOres(BlockType.Lava);
        }
        private void GenerateTerrian()
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
                    GenerateFillarOfDirt(l, k, random);
                }
            }
        }

        private void GenerateFillarOfDirt(int BlockY, int BlockX, int random)
        {
            if (random - 1 == BlockY)
            {
                manager.AddBlockTile(BlockX, BlockY, BlockType.Grass);
            }
            else
            {
                manager.AddBlockTile(BlockX, BlockY, BlockType.Dirt);
            }
        }

        

        private void GenerateTrees()
        {
            foreach (var item in manager.Blocks.FindAll(s => s.Id == BlockType.Grass))
            {
                var size = Parameters.BlockSize;
                var ranSel = randomizer.Next(0, Parameters.treeChance) == 0;
                var HasSize = item.Position.Y >= Parameters.minimumFillarHeightForTree * Parameters.BlockSize;
                var IsAwayFromTrees = CanGenerateTree == 3;

                if (ranSel && HasSize && IsAwayFromTrees) generateTree(item.Position.X / size, item.Position.Y / size);
                else if (CanGenerateTree != Parameters.TreeSpread) CanGenerateTree++;
            }
        }

        private void GenerateWater()
        {           
            for (int X = -size; X < size; X++)
            {
                bool FirstBlock = true;
                for (int i = Parameters.WaterLevel; i > -1; i--)
                {
                    var placedFluid = manager.AddFluid(X, i, BlockType.Water,false);                 
                    if (!placedFluid) 
                    {
                        if (FirstBlock) break;
                        manager.AddBlockTile(X, i, BlockType.Sand,true,true);
                        break;
                    }
                    FirstBlock = false;
                }
            }
        }

        private void generateTree(int X, int Y)
        {
            for (int i = Y + 1; i < Y + 4; i++)
            {
                manager.AddBlockTile(X, i, BlockType.Wood);
            }
            manager.AddBlockTile(X, Y + 4, BlockType.Leaves);
            manager.AddBlockTile(X - 1, Y + 3, BlockType.Leaves);
            manager.AddBlockTile(X + 1, Y + 3, BlockType.Leaves);
            CanGenerateTree = 0;
        }

        private void CreateUnderGround()
        {
            for (int X = -size; X < size; X++)
            {
                GenerateCollumnOfStone(X);
            }
        }

        private void GenerateCollumnOfStone(int X)
        {
            for (int Y = -1; Y > -Parameters.sizeOfStoneCollumn; Y--)
            {
                manager.AddBlockTile(X, Y, BlockType.Stone);
            }
        }

        private void GenerateOres(BlockType type)
        {
            var offset = Parameters.ChunkSize;
            var count = oreTable.GetCount(type);
            var GenerateAsFluid = oreTable.IsFluid(type);
            var pointer = -size;
            var chunks = size * 2 / offset;

            if (size % 10 != 0) chunks++;
            for (int c = 0; c < chunks; c++)
            {
                for (int i = 0; i < count; i++)
                {
                    var X = randomizer.Next(pointer, pointer + offset);
                    var Y = randomizer.Next(-Parameters.sizeOfStoneCollumn, -oreTable.GetMinimumDepth(type));
                    GenerateOre(X, Y, type, oreTable.GetChance(type),GenerateAsFluid);
                }
                pointer += offset;
            }
        }

        private void GenerateOre(int X, int Y, BlockType type, int bitSpawnChance, bool generateAsFluid)
        {
            AddOreNode(X, Y, type,generateAsFluid);
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    GenerateBit(X - x, Y - y, type, bitSpawnChance,generateAsFluid);
                }
            }
        }

        private void AddOreNode(int X, int Y, BlockType type,bool GenerateAsFluid)
        {
            if (GenerateAsFluid) manager.AddFluid(X, Y, type,true,true);          
                else manager.AddBlockTile(X, Y, type, true,true);          
        }

        private void GenerateBit(int X, int Y, BlockType type, int spawnChance,bool IsFluid)
        {
            if (randomizer.Next(0, spawnChance) == 0) AddOreNode(X, Y, type, IsFluid);
        }
    }
}