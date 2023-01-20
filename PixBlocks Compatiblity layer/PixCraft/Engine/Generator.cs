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

        private readonly IOreTable oreTable;
        private int size;
        private List<Vector2> OrePositions = new List<Vector2>();
        private readonly IDrawer drawer;

        public IGeneratorParameters parameters { get; }
        private readonly World world;

        public Generator(World tiles, IOreTable oreTable,IDrawer drawer,IGeneratorParameters parameters)
        {
            this.world = tiles;
            this.oreTable = oreTable;
            this.drawer = drawer;
            this.parameters = parameters;
            CanGenerateTree = this.parameters.TreeSpread;
        }

        public void GenerateWorld(int seed,int size)
        {
            randomizer = new Random(seed);
            this.size = size;

            GenerateTerrian(); //* no water for YOU
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
                world.SetBlock(new BlockData(BlockX, BlockY, BlockType.Grass));
            }
            else
            {
                world.SetBlock(new BlockData(BlockX, BlockY, BlockType.Dirt));
            }
        }

        

        private void GenerateTrees()
        {
            foreach (var item in world.GetAllThat(s => s.Type == BlockType.Grass))
            {
                var size = Parameters.BlockSize;
                var ranSel = randomizer.Next(0, parameters.treeChance) == 0;
                var HasSize = item.Y >= parameters.minimumFillarHeightForTree;
                var IsAwayFromTrees = CanGenerateTree == 3;

                if (ranSel && HasSize && IsAwayFromTrees) generateTree(item.X , item.Y);
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
                    var placedFluid = world.SetBlock(X, i, BlockType.Water);                 
                    if (!placedFluid) 
                    {
                        if (FirstBlock) break;
                        world.RemoveBlock(world.GetBlock(X,i));
                        world.SetBlock(X, i, BlockType.Sand);
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
                world.SetBlock(X, i, BlockType.Wood);
            }
            world.SetBlock(X, Y + 4, BlockType.Leaves);
            world.SetBlock(X - 1, Y + 3, BlockType.Leaves);
            world.SetBlock(X + 1, Y + 3, BlockType.Leaves);
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
                world.SetBlock(X, Y, BlockType.Stone);
            }
        }

        private void GenerateOres(BlockType type)
        {
            var offset = parameters.ChunkSize;
            var count = oreTable.GetCount(type);
            var pointer = -size;
            var chunks = size * 2 / offset;

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

        private void GenerateOre(int X, int Y, BlockType type, int bitSpawnChance)
        {
            AddOreNode(X, Y, type);
            for (int x = -1; x < 2; x++)
            {
                for (int y = -1; y < 2; y++)
                {
                    GenerateBit(X - x, Y - y, type, bitSpawnChance);
                }
            }
        }

        private void AddOreNode(int X, int Y, BlockType type)
        {
            if (Math.Abs(X) > size||Math.Abs(Y)>=parameters.sizeOfStoneCollumn) return;      
            world.SetBlock(X, Y, type);
            OrePositions.Add(new Vector2(X, Y));
        }

        private void GenerateBit(int X, int Y, BlockType type, int spawnChance)
        {
            if (randomizer.Next(0, spawnChance) == 0) AddOreNode(X, Y, type);
        }
    }
}