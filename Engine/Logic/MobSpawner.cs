using Engine.Engine;
using Engine.Engine.models;
using Engine.Entities;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.Logic
{
    public class MobSpawner:Sprite
    {
        public MobSpawner(Engine.Engine engine,IActiveElements activeElements,IDrawer drawer,IPixSound sound)
        {
            size = 0;
            Engine = engine;
            ActiveElements = activeElements;
            Drawer = drawer;
            Sound = sound;
            Randomizer = new Random();
            
        }

        public Engine.Engine Engine { get; }
        public IActiveElements ActiveElements { get; }
        public IDrawer Drawer { get; }
        public IPixSound Sound { get; }
        public Random Randomizer { get; }

        public override void update()
        {
            if(Randomizer.Next(50) == 0 && Engine.entities.Count < 5)
            {
                var zombie = new Zombie(ActiveElements, Drawer, Sound, new Parameters());
                zombie.status.OnKill = () => Kill(zombie);
                zombie.Position.X = Randomizer.Next(-110, 110);
                Engine.entities.Add(zombie);
            }
        }

        private void Kill(SpriteOverlay sprite)
        {
            Engine.entities.Remove(sprite);
            Drawer.remove(sprite);
        }
    }
}
