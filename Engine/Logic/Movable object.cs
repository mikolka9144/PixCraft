using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using System;
using System.Linq;

namespace Engine.Logic
{
    internal abstract class Movable_object : SpriteOverlay
    {
        protected readonly IMoveDefiner moveDefiner;
        protected readonly PlayerStatus status;

        protected event Action OnDamageDeal;

        private bool Grounded;
        private int TicksElapsed;
        private int speed;
        private int TicksElapsedForMove;
        private int DistanceFalled;

        public Movable_object(IActiveElements ActiveElements,IDrawer drawer, IMoveDefiner moveDefiner, PointerController pointer, PlayerStatus status):base(0,0,drawer)
        {
            this.ActiveElements = ActiveElements;
            this.moveDefiner = moveDefiner;
            Pointer = pointer;
            this.status = status;
            speed = 0;
            Grounded = false;
            TicksElapsed = Parameters.BlocksCollisionDelay;
            TicksElapsedForMove = Parameters.MoveDelay;
        }

        public IActiveElements ActiveElements { get; }
        public PointerController Pointer { get; }

        public override void update()
        {
            if (moveDefiner.key(command.Left) && TicksElapsedForMove >= Parameters.MoveDelay)
            {
                MoveLeft();
            }
            else if (moveDefiner.key(command.Right) && TicksElapsedForMove >= Parameters.MoveDelay)
            {
                MoveRight();
            }
            ApplyGravity();
            ApplyBlocksCollisions();
        }

        private void ApplyBlocksCollisions()
        {
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b))
                {
                    if (speed > 0)
                    {
                        TicksElapsed = 0;
                        TicksElapsedForMove = 0;
                        speed = -speed;
                    }
                    else if (collide(b.foliage) && TicksElapsed == Parameters.BlocksCollisionDelay) 
                    Move(roation.Up, Parameters.StandUpSpeed);
                }
            }
            if (TicksElapsed != Parameters.BlocksCollisionDelay) TicksElapsed++;
            if (TicksElapsedForMove != Parameters.MoveDelay) TicksElapsedForMove++;
        }

        private void ApplyGravity()
        {
            if (moveDefiner.key(command.Jump) && Grounded)
            {
                Grounded = false;
                speed = Parameters.MaxFallSpeed;
            }
            foreach (var block in ActiveElements.ActiveToppings)
            {
                if (collide(block) && TicksElapsed >= Parameters.BlocksCollisionDelay)
                {
                    Grounded = true;
                    Pointer.LastFoliage = block;
                    if (speed < 0) speed = 0;
                    if (status.DealDamage(DistanceFalled)) OnDamageDeal.Invoke();
                    DistanceFalled = 0;
                    break;
                }
            }
            Move(roation.Up, speed);
            ChangeMoveSpeed();
            
        }

        private void ChangeMoveSpeed()
        {
            if (speed < 0) DistanceFalled -= speed;
            if (speed > -Parameters.MaxFallSpeed) speed -= 1;
        }

        private void MoveRight()
        {
            flip = false;
            if(!ActiveElements.ActiveBlocks.Any(s => s.collide(this)))
                Move(roation.Left, Parameters.moveSpeed);
        }

        private void MoveLeft()
        {
            flip = true;
            Move(roation.Right, Parameters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b))
                {
                    Move(roation.Left, Parameters.moveSpeed);
                    break;
                }
            }
        }
    }
}