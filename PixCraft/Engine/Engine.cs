using Engine.Engine.models;
using Engine.Logic;
using Engine.Resources;
using Integration;
using System.Collections.Generic;

namespace Engine.Engine
{
    public class Engine : IMover,IEntitiesData
    {
        public BlockIdProcessor IdProcessor = new BlockIdProcessor();

        public Center Center;
        private readonly IDrawer drawer;

        public ITileManager manager { get; }
        public List<IStoppableSpriteOverlay> Sprites { get; } = new List<IStoppableSpriteOverlay>();
        public List<IStoppableSpriteOverlay> entities { get; } = new List<IStoppableSpriteOverlay>();

        public Engine(ITileManager tileManager, IDrawer drawer)
        {
            Center = new Center(drawer);
            manager = tileManager;
            this.drawer = drawer;
        }

        public void Add(IStoppableSpriteOverlay sprite)
        {
            Sprites.Add(sprite);
        }

        internal void Stop()
        {
            Sprites.ForEach(s => s.Active = false);
            entities.ForEach(s => s.Active = false);

        }

        public void Render()
        {
            foreach (var item in manager.Blocks)
            {
                drawer.Draw(item);
            }
            foreach (var item in manager.Fluids)
            {
                drawer.Draw(item);
            }
        }

        internal void Start()
        {
            Sprites.ForEach(s => s.Active = true);
            entities.ForEach(s => s.Active = true);
        }

        public void Move(roation roation, int lenght)
        {
            foreach (Block block in manager.Blocks)
            {
                block.move(roation, lenght);
            }
            foreach (SpriteOverlay spriteOverlay in Sprites)
            {
                spriteOverlay.move(roation, lenght);
            }
            foreach (SpriteOverlay spriteOverlay in entities)
            {
                spriteOverlay.move(roation, lenght);
            }
            foreach (var item in manager.Fluids)
            {
                item.move(roation, lenght);
            }
            Center.move(roation, lenght);
        }
    }

    public interface IDrawer
    {
        void Draw(SpriteOverlay sprite);

        void remove(GenericSprite sprite);
    }
}