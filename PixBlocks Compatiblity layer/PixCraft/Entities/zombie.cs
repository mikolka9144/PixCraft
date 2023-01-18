using Engine.Engine;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Logic;
using Engine.Resources;
using System.Timers;
using System;
using Integration;

namespace Engine.Entities
{
    class Zombie : MovableObject,IDisposable
    {
        public Zombie(IActiveElements ActiveElements, IDrawer drawer, IPixSound sound,Parameters parameters,Player player) : base(ActiveElements, drawer, null, new PlayerStatus(null, parameters), sound, parameters)
        {
            size = 10;
            parameters.moveSpeed = 3;
            parameters.DefaultColor = new Color(204, 51, 102);
            color = parameters.DefaultColor;
            var logic = new Monster_AI(this);
            OnWallHit += logic.Zombie_OnWallHit;
            moveDefiner = logic;
            Player = player;
            Timer = new Timer(2500);
            Timer.Elapsed += Timer_Elapsed;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CanHit = true;
        }

        public Player Player { get; }

        private Timer Timer;
        private bool CanHit = true;

        public override void update()
        {
            base.update();
            if (CollideSystem.collide(Player,this) && CanHit)
            {
                Player.DealAttackDamage(2);
                CanHit = false;
            }       
        }

        public void Dispose()
        {
            Timer.Dispose();
        }
    }
}
