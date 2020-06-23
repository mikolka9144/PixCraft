using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BlockEngine
{
    public class Engine : IDrawer
    {
        public SpriteOverlay Center;

        public Engine()
        {
            Center = new Center(this);
        }

        public Pointer GetPointer()
        {
            Pointer pointer = new Pointer(this);
            this.Sprites.Add(pointer);
            return pointer;
        }

        // Token: 0x06000012 RID: 18 RVA: 0x000022FC File Offset: 0x000004FC
        public void LoadMap(string MapData)
        {
            List<string> list = MapData.Split(new char[]
            {
                '#'
            }).ToList<string>();
            string[] array = list[0].Split(new char[]
            {
                '*'
            });
            var playerPos = (Convert.ToInt32(array[0]), Convert.ToInt32(array[1]));
            list.RemoveAt(0);
            foreach (string text in list)
            {
                string[] array2 = text.Split(new char[]
                {
                    '*'
                });
                int num = Convert.ToInt32(array2[0]);
                int x = Convert.ToInt32(array2[1]);
                int y = Convert.ToInt32(array2[2]);
                int id = Convert.ToInt32(array2[3]);
                int num2 = Convert.ToInt32(array2[4]);
                bool flag = num <= -1;
                if (flag)
                {
                    this.AddBlockTile(x, y, id, num2, false);
                }
                else
                {
                    this.Add(new SpriteOverlay(new Sprite
                    {
                        image = num,
                        size = num2
                    }, x, y, id, this));
                }
            }
            this.MoveScene(playerPos.Item1, playerPos.Item2);
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00002444 File Offset: 0x00000644
        public void CreateGenerator(int seed, int size)
        {
            try
            {
                this.randomizer = new Random(seed);
                GenerateNext(0, size / 2);
                this.GenerateNext(-1, size / 2);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        // Token: 0x06000014 RID: 20 RVA: 0x0000246C File Offset: 0x0000066C
        public void RemoveTile(Block tile)
        {
            GameScene.gameSceneStatic.remove(tile.Sprite);
            GameScene.gameSceneStatic.remove(tile.foliage.Sprite);
            this.Blocks.Remove(tile);
            this.Toppings.Remove(tile.foliage);
        }

        // Token: 0x06000015 RID: 21 RVA: 0x000024C0 File Offset: 0x000006C0
        internal void GenerateNext(int offset, int blocks)
        {
            if (offset < 0)
            {
                for (int i = -blocks; i < offset; i++)
                {
                    for (int j = 0; j < randomizer.Next(1, 5); j++)
                    {
                        this.AddBlockTile(20 * i, 20 * j + (int)this.Center.Y, 1, 20, false);
                    }
                }
            }
            else
            {
                for (int k = offset; k < blocks; k++)
                {
                    for (int l = 0; l < this.randomizer.Next(1, 5); l++)
                    {
                        this.AddBlockTile(20 * k, 20 * l + (int)this.Center.Y, 1, 20, false);
                    }
                }
            }
        }

        // Token: 0x06000016 RID: 22 RVA: 0x0000258D File Offset: 0x0000078D
        private void MoveScene(int X, int Y)
        {
            this.Move(-180.0, X);
            this.Move(-90.0, Y);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000025BE File Offset: 0x000007BE
        public void Add(SpriteOverlay sprite)
        {
            this.Sprites.Add(sprite);
        }

        // Token: 0x06000018 RID: 24 RVA: 0x000025D0 File Offset: 0x000007D0
        public void AddBlockTile(int X, int Y, int Id, int size, bool SholdDraw)
        {
            Block block = new Block(X, Y, Id, size, this);
            this.Blocks.Add(block);
            Toppings.Add(block.foliage);
            if (SholdDraw)
            {
                Draw(block);
                this.Draw(block.foliage);
            }
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002628 File Offset: 0x00000828
        public void Draw(SpriteOverlay sprite)
        {
            bool flag = sprite.X > 100.0 || sprite.X < -100.0 || sprite.Y > 100.0 || sprite.Y < -100.0;
            if (flag)
            {
                sprite.Sprite.IsVisible = false;
                this.VisibleSprites.Remove(sprite);
            }
            else
            {
                sprite.Sprite.position = new PixBlocks.PythonIron.Tools.Integration.Vector(sprite.X, sprite.Y);
                bool flag2 = !sprite.IsVisible;
                if (flag2)
                {
                    this.addSpriteToGame(sprite);
                }
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000026D8 File Offset: 0x000008D8
        private void addSpriteToGame(SpriteOverlay sprite)
        {
            bool flag = !this.VisibleSprites.Contains(sprite);
            if (flag)
            {
                this.VisibleSprites.Add(sprite);
                GameScene.gameSceneStatic.add(sprite.Sprite);
            }
        }

        // Token: 0x0600001B RID: 27 RVA: 0x0000271C File Offset: 0x0000091C
        public void Move(double roation, double lenght)
        {
            foreach (Block block in this.Blocks)
            {
                block.Move(roation, lenght);
            }
            foreach (SpriteOverlay spriteOverlay in this.Sprites)
            {
                spriteOverlay.Move(roation, lenght);
            }
            foreach (Foliage foliage in this.Toppings)
            {
                foliage.Move(roation, lenght);
            }
            this.Center.Move(roation, lenght);
        }

        // Token: 0x04000008 RID: 8
        public List<Block> Blocks = new List<Block>();

        // Token: 0x0400000A RID: 10
        public List<SpriteOverlay> VisibleSprites = new List<SpriteOverlay>();

        // Token: 0x0400000C RID: 12
        public List<Foliage> Toppings = new List<Foliage>();

        // Token: 0x0400000D RID: 13
        public List<SpriteOverlay> Sprites = new List<SpriteOverlay>();

        // Token: 0x0400000E RID: 14
        private Random randomizer;

        // Token: 0x0400000F RID: 15
        private const int border = 100;
    }
}