﻿using Engine.Engine.models;
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
        private readonly IDrawer drawer;

        public ITileManager manager { get; }

        public Engine(ITileManager tileManager, IDrawer drawer)
        {
            Center = new Center(drawer);
            manager = tileManager;
            this.drawer = drawer;
        }

        public void Add(SpriteOverlay sprite)
        {
            Sprites.Add(sprite);
        }
        public void Render()
        {
            foreach (var item in manager.Blocks)
            {
                drawer.Draw(item);
            }
            foreach (var item in manager.Toppings)
            {
                drawer.Draw(item);
            }
            foreach (var item in manager.Fluids)
            {
                drawer.Draw(item);
            }
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
            foreach (Foliage foliage in manager.Toppings)
            {
                foliage.move(roation, lenght);
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

        void remove(Sprite sprite);
    }
}