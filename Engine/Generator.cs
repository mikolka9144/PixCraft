using System;

namespace BlockEngine
{
    internal class Generator
    {
        private Random randomizer;
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
                    if (random - 1 == j)
                    {
                        manager.AddBlockTile(20 * i, 20 * j, 1, 20, false);
                    }
                    else
                    {

                        manager.AddBlockTile(20 * i, 20 * j, 2, 20, false);
                    }
                }
            }
            for (int k = 0; k < blocks; k++)
            {
                var random = randomizer.Next(1, 5);
                for (int l = 0; l < random; l++)
                {
                    if (random - 1 == l)
                    {
                        manager.AddBlockTile(20 * k, 20 * l, 1, 20, false);

                    }
                    else
                    {

                        manager.AddBlockTile(20 * k, 20 * l, 2, 20, false);
                    }
                }
            }

        }

        internal void CreateUnderGround(int size)
        {
            for (int i = -size; i < 0; i++)
            {
                GenerateCollumn(i * 20);
            }
            for (int i = 0; i < size; i++)
            {
                GenerateCollumn(i * 20);
            }
        }

        private void GenerateCollumn(int X)
        {
            for (int i = -1; i > -sizeOfCollumn; i--)
            {
                manager.AddBlockTile(X, i * 20, 3, 20, false);
            }
        }
    }
}