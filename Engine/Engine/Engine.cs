using Engine.Engine.models;
using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Engine.Engine
{
    public class Engine : IDrawer,IActiveElements,IMover
    {
        public List<Block> Blocks = new List<Block>();
        public List<Block> ActiveBlocks => Blocks.FindAll(s => s.IsActiveBlock()).ToList();

        public List<Foliage> Toppings = new List<Foliage>();
        public List<Foliage> ActiveToppings => Toppings.FindAll(s => s.IsActiveBlock()).ToList();

        public BlockIdProcessor IdProcessor = new BlockIdProcessor();
        public List<SpriteOverlay> Sprites = new List<SpriteOverlay>();
        

        public Center Center;
        public readonly Parameters parameters;

        public Engine(Parameters paramters)
        {
            Center = new Center(this,paramters);
            this.parameters = paramters;
        }

        public void RemoveTile(Block tile)
        {
            GameScene.gameSceneStatic.remove(tile.Sprite);
            GameScene.gameSceneStatic.remove(tile.foliage.Sprite);
            this.Blocks.Remove(tile);
            this.Toppings.Remove(tile.foliage);
        }

        // Token: 0x06000016 RID: 22 RVA: 0x0000258D File Offset: 0x0000078D
        public void MoveScene(int X, int Y)
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
            Block block = new Block(X, Y, Id, size, this, IdProcessor,parameters);
            AddBlockTile(block, SholdDraw);
        }
        public void AddBlockTile(Block block,bool ShouldDraw)
        {
            this.Blocks.Add(block);
            Toppings.Add(block.foliage);
            if (ShouldDraw)
            {
                Draw(block);
                Draw(block.foliage);
            }
        }

        // Token: 0x06000019 RID: 25 RVA: 0x00002628 File Offset: 0x00000828
        public void Draw(SpriteOverlay sprite)
        {
            
             var flag = sprite.X > parameters.border.Left || sprite.X < -parameters.border.Right || 
                sprite.Y > parameters.border.Up || sprite.Y < -parameters.border.Down;
            
            if (flag)
            {
                sprite.Sprite.IsVisible = false;
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
            if (!sprite.Sprite.IsVisible)
            {
                Thread.Sleep(parameters.Delay);
                GameScene.gameSceneStatic.add(sprite.Sprite);
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

        
    }

    public interface ITileManager
    {
        ///<summary>
        ///Creates a block with collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id,bool replace, bool forceReplace = false);
        ///<summary>
        ///Creates a block without collision check
        ///</summary>
        void AddBlockTile(int BlockX, int BlockY, BlockType Id);
        List<Block> Blocks { get; }
    }

    public interface IDrawer
    {
        void Draw(SpriteOverlay sprite);
    }
}