using Engine.Engine.models;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;

namespace Engine.Engine
{
    public class Engine : IMover
    {
        public BlockIdProcessor IdProcessor = new BlockIdProcessor();
        public List<SpriteOverlay> Sprites = new List<SpriteOverlay>();

        public Center Center;
        public readonly Parameters parameters;

        public ITileManager TileManager { get; }

        public Engine(ITileManager tileManager, IDrawer drawer)
        {
            Center = new Center(drawer);
            TileManager = tileManager;
        }

        // Token: 0x06000016 RID: 22 RVA: 0x0000258D File Offset: 0x0000078D

        // Token: 0x06000017 RID: 23 RVA: 0x000025BE File Offset: 0x000007BE
        public void Add(SpriteOverlay sprite)
        {
            this.Sprites.Add(sprite);
        }

        // Token: 0x06000018 RID: 24 RVA: 0x000025D0 File Offset: 0x000007D0

        // Token: 0x06000019 RID: 25 RVA: 0x00002628 File Offset: 0x00000828

        public void Move(roation roation, int lenght)
        {
            foreach (Block block in TileManager.Blocks)
            {
                block.Move(roation, lenght);
            }
            foreach (SpriteOverlay spriteOverlay in Sprites)
            {
                spriteOverlay.Move(roation, lenght);
            }
            foreach (Foliage foliage in TileManager.Toppings)
            {
                foliage.Move(roation, lenght);
            }
            foreach (var item in TileManager.Fluids)
            {
                item.Move(roation, lenght);
            }
            Center.Move(roation, lenght);
        }
    }

    public interface IDrawer
    {
        void Draw(SpriteOverlay sprite);

        void remove(Sprite sprite);
    }
}