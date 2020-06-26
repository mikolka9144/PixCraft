using Engine.Engine.models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Engine.Engine
{
    public class Engine : IDrawer, ITileManager,IActiveElements
    {
        public List<Block> Blocks = new List<Block>();
        public List<Block> ActiveBlocks => Blocks.FindAll(s => IsActiveBlock(s)).ToList();

        public List<Foliage> Toppings = new List<Foliage>();
        public List<Foliage> ActiveToppings => Toppings.FindAll(s => IsActiveBlock(s)).ToList();

        public BlockIdProcessor IdProcessor = new BlockIdProcessor();
        public List<SpriteOverlay> Sprites = new List<SpriteOverlay>();
        

        public SpriteOverlay Center;
        private readonly Parameters paramters;

        public Engine(Parameters paramters)
        {
            Center = new Center(this);
            this.paramters = paramters;
        }

        // Token: 0x06000013 RID: 19 RVA: 0x00002444 File Offset: 0x00000644
        public void CreateGenerator(int seed, int size)
        {
            var generator = new Generator(seed, this,paramters);
            generator.GenerateTerrian(size);
            generator.CreateUnderGround(size);
        }

        // Token: 0x06000014 RID: 20 RVA: 0x0000246C File Offset: 0x0000066C
        public void RemoveTile(Block tile)
        {
            GameScene.gameSceneStatic.remove(tile.Sprite);
            GameScene.gameSceneStatic.remove(tile.foliage.Sprite);
            this.Blocks.Remove(tile);
            this.Toppings.Remove(tile.foliage);
        }

        // Token: 0x06000016 RID: 22 RVA: 0x0000258D File Offset: 0x0000078D
        private void MoveScene(int X, int Y)
        {
            this.Move(roation.Right, X);
            this.Move(roation.Down, Y);
        }

        // Token: 0x06000017 RID: 23 RVA: 0x000025BE File Offset: 0x000007BE
        public void Add(SpriteOverlay sprite)
        {
            this.Sprites.Add(sprite);
        }

        // Token: 0x06000018 RID: 24 RVA: 0x000025D0 File Offset: 0x000007D0
        public void AddBlockTile(int X, int Y, BlockType Id, int size, bool SholdDraw)
        {
            Block block = new Block(X, Y, Id, size, this, IdProcessor);
            this.Blocks.Add(block);
            Toppings.Add(block.foliage);
            if (SholdDraw)
            {
                Draw(block);
                Draw(block.foliage);
            }
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002628 File Offset: 0x00000828
        public void Draw(SpriteOverlay sprite)
        {
            bool flag = sprite.X > paramters.border.Left || sprite.X < -paramters.border.Right || 
                sprite.Y > paramters.border.Up || sprite.Y < -paramters.border.Down;
            if (flag)
            {
                sprite.Sprite.IsVisible = false;
                sprite.IsRendered = false;
            }
            else
            {
                sprite.Sprite.position = new PixBlocks.PythonIron.Tools.Integration.Vector(sprite.X, sprite.Y);
                bool flag2 = !sprite.Sprite.IsVisible;
                if (flag2)
                {
                    AddSpriteToGame(sprite);
                }
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000026D8 File Offset: 0x000008D8
        private void AddSpriteToGame(SpriteOverlay sprite)
        {
            if (!sprite.IsRendered)
            {
                Thread.Sleep(paramters.Delay);
                GameScene.gameSceneStatic.add(sprite.Sprite);
                sprite.IsRendered = true;
            }
        }

        public void Move(roation roation, int lenght)
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

        private bool IsActiveBlock(SpriteOverlay sprite)
        {
            var isActive = sprite.IsRendered;
            var IsNotInRange = sprite.X > paramters.hitboxArea.Right || sprite.X < -paramters.hitboxArea.Left 
                || sprite.Y > paramters.hitboxArea.Up || sprite.Y < paramters.hitboxArea.Down;
            return isActive && IsNotInRange;
        }
    }

    public interface ITileManager
    {
        void Add(SpriteOverlay sprite);

        void Move(roation roation, int lenght);

        void AddBlockTile(int X, int Y, BlockType Id, int size, bool SholdDraw);

        void RemoveTile(Block tile);
    }

    public interface IDrawer
    {
        void Draw(SpriteOverlay sprite);
    }
}