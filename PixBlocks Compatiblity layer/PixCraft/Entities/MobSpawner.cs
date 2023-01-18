using Engine.Engine;
using Engine.Entities;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using Integration;
using System;
using System.Linq;

namespace Engine.Logic
{
    internal class MobSpawner:GenericSprite
    {
        public MobSpawner(IEntitiesData engine,IActiveElements activeElements,IDrawer drawer,IPixSound sound, Player player)
        {
            size = 0;
            Engine = engine;
            Player = player;
            ActiveElements = activeElements;
            Drawer = drawer;
            Sound = sound;
            Randomizer = new Random();
            
        }

        public IEntitiesData Engine { get; }

        private Player Player;

        public IActiveElements ActiveElements { get; }
        public IDrawer Drawer { get; }
        public IPixSound Sound { get; }
        public Random Randomizer { get; }

        public override void update()
        {
            if(Randomizer.Next(200) == 0 && Engine.entities.Count < 2)
            {
                var zombie = new Zombie(ActiveElements, Drawer, Sound, new Parameters(),Player);
                zombie.status.OnKill = () => Kill(zombie);
                zombie.position.x = Randomizer.Next(-110, 110);
                zombie.position.y = 70;
                if(!ActiveElements.GetActiveBlocks(zombie.position).Any(s =>s.Collide(zombie)))Engine.entities.Add(zombie);
            }
            for (int i = 0; i < Engine.entities.Count(); i++)
            {
                var zombie = Engine.entities[i] as MovableObject;
                if (!zombie.IsInRange(150)) Engine.entities.Remove(zombie);
            }
        }

        private void Kill(MovableObject sprite)
        {
            Drawer.remove(sprite);
            Engine.entities.Remove(sprite);
            sprite.Active = false;
        }
    }
}
