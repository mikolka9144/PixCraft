using Engine.Engine.models;
using Engine.Logic;
using Engine.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Engine
{
    internal class Generator
    {
        private Random randomizer;
        private int CanGenerateTree;

        private readonly ITileManager manager;
        private readonly IOreTable oreTable;
        private int size;
        private List<Vector2> OrePositions = new List<Vector2>();
        private readonly IDrawer drawer;

        public IGeneratorParameters parameters { get; }

        public Generator(ITileManager manager, IOreTable oreTable,IDrawer drawer,IGeneratorParameters parameters)
        {
            
            this.manager = manager;
            this.oreTable = oreTable;
            this.drawer = drawer;
            this.parameters = parameters;
            CanGenerateTree = this.parameters.TreeSpread;
        }

        public void GenerateWorld(int seed,int size)
        {
            randomizer = new Random(seed);
            this.size = size;

            GenerateTerrian();
            GenerateWater();
            GenerateTrees();
            GenerateOres(BlockType.CoalOre);
            GenerateOres(BlockType.IronOre);
            GenerateOres(BlockType.GoldOre);
            GenerateOres(BlockType.DiamondOre);
            GenerateOres(BlockType.Lava);
            CreateUnderGround();
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
                var ranSel = randomizer.Next(0, parameters.treeChance) == 0;
                var HasSize = item.position.y >= parameters.minimumFillarHeightForTree * Parameters.BlockSize;
                var IsAwayFromTrees = CanGenerateTree == 3;

                if (ranSel && HasSize && IsAwayFromTrees) generateTree(item.position.x / size, item.position.y / size);
                else if (CanGenerateTree != parameters.TreeSpread) CanGenerateTree++;
            }
        }

        private void GenerateWater()
        {           
            for (int X = -size; X < size; X++)
            {
                bool FirstBlock = true;
                for (int i = parameters.WaterLevel; i > -1; i--)
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
            for (int Y = -1; Y > -parameters.sizeOfStoneCollumn; Y--)
            {
                if (OrePositions.Any(s => s.x == X && s.y == Y)) continue;
                manager.AddBlockTile(X, Y, BlockType.Stone);
            }
        }

        private void GenerateOres(BlockType type)
        {
            var offset = parameters.ChunkSize;
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
                    var Y = randomizer.Next(-parameters.sizeOfStoneCollumn, -oreTable.GetMinimumDepth(type));
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
            if (Math.Abs(X) > size||Math.Abs(Y)>=parameters.sizeOfStoneCollumn) return;
            if (GenerateAsFluid) manager.AddFluid(X, Y, type);          
                else manager.AddBlockTile(X, Y, type);
            OrePositions.Add(new Vector2(X, Y));
        }

        private void GenerateBit(int X, int Y, BlockType type, int spawnChance,bool IsFluid)
        {
            if (randomizer.Next(0, spawnChance) == 0) AddOreNode(X, Y, type, IsFluid);
        }
    }
}