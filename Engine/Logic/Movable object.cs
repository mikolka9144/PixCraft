using Engine.Engine;
using Engine.Engine.models;
using Engine.Resources;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class MovableObject : SpriteOverlay
    {
        protected readonly IMoveDefiner moveDefiner;
        protected readonly PlayerStatus status;

        public virtual void OnDamageDeal()
        {
            Task.Run(() =>
            {
                color = Parameters.RedColor;
                Thread.Sleep(600);
                color = Parameters.DefaultColor;
            });
        }

        private bool Grounded;
        private int TicksElapsed;
        private int speed;
        private int TicksElapsedForMove;
        private int DistanceFalled;
        private int WaterTicks = 0;

        public MovableObject(IActiveElements ActiveElements,IDrawer drawer, IMoveDefiner moveDefiner, PointerController pointer, PlayerStatus status):base(0,0,drawer)
        {
            status.OnDamageDeal = OnDamageDeal;
            this.ActiveElements = ActiveElements;
            this.moveDefiner = moveDefiner;
            Pointer = pointer;
            this.status = status;
            speed = 0;
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
            CheckIfUnderwater();
        }

        public void CheckIfUnderwater()
        {
            foreach (var item in ActiveElements.ActiveFluids)
            {
                if(collide(item))
                {
                    WaterTicks++;
                    if (WaterTicks > 19)
                    {
                        status.DealBreathBuuble();
                        WaterTicks = 0;
                    }
                    return;
                }
            }
            status.RestoreBreath();      
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
                    move(roation.Up, Parameters.StandUpSpeed);
                }
            }
            if (TicksElapsed != Parameters.BlocksCollisionDelay) TicksElapsed++;
            if (TicksElapsedForMove != Parameters.MoveDelay) TicksElapsedForMove++;
        }

        private void ApplyGravity()
        {
            var touchesWater = ActiveElements.ActiveFluids.FindAll(s => s.Id == BlockType.Water).Any(s => collide(s));
            if (moveDefiner.key(command.Jump) && Grounded)
            {
                Grounded = false;
                
                speed = touchesWater?Parameters.WaterJumpSpeed:Parameters.MaxFallSpeed;
            }
            foreach (var block in ActiveElements.ActiveToppings)
            {
                if (collide(block) && TicksElapsed >= Parameters.BlocksCollisionDelay)
                {
                    Grounded = true;
                    if (speed < 0) speed = 0;
                    status.DealDamage(DistanceFalled);
                    DistanceFalled = 0;
                    break;
                }
            }
            move(roation.Up, speed);
            ChangeMoveSpeed(touchesWater);
            
        }

        private void ChangeMoveSpeed(bool touchesWater)
        {
            if (speed < 0) DistanceFalled -= speed;
            if(touchesWater)
            {
                DistanceFalled = 0;
                if (speed > -Parameters.MaxWaterFallSpeed) speed -= 1;
                if (speed < -Parameters.MaxWaterFallSpeed) speed += 1;
                Grounded = true;
            }
            else
            {

                if (speed > -Parameters.MaxFallSpeed) speed -= 1;
            }
            
        }

        private void MoveRight()
        {
            flip = false;
            move(roation.Right, Parameters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b))
                {
                    move(roation.Left, Parameters.moveSpeed);
                    break;
                }
            }
        }

        private void MoveLeft()
        {
            flip = true;
            move(roation.Left, Parameters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b))
                {
                    move(roation.Right, Parameters.moveSpeed);
                    break;
                }
            }
        }
    }
}