using Engine.Engine;
using Engine.Engine.models;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Resources;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Engine.Logic
{
    public class MovableObject : SpriteOverlay, IStoppableSpriteOverlay
    {
        protected IMoveDefiner moveDefiner;
        internal PlayerStatus status;
        protected event EventHandler OnWallHit;

        public virtual void OnDamageDeal()
        {
            new Task(() =>
            {
                color = Parameters.RedColor;
                Thread.Sleep(600);
                color = Parameters.DefaultColor;
            }).Start();
        }

        private bool Grounded;
        private int TicksElapsed;
        private int speed;
        private int DistanceFalled;
        private int WaterTicks = 0;
        private bool IsInWater;


        public MovableObject(IActiveElements ActiveElements, IDrawer drawer, IMoveDefiner moveDefiner, PlayerStatus status, IPixSound sound, IMovableObjectParameters parameters) : base(0, 0, drawer)
        {
            status.OnDamageDeal = OnDamageDeal;
            this.ActiveElements = ActiveElements;
            this.moveDefiner = moveDefiner;
            this.status = status;
            Sound = sound;
            Parameters = parameters;
            speed = 0;
            TicksElapsed = Parameters.BlocksCollisionDelay;
        }

        public IActiveElements ActiveElements { get; }
        public IPixSound Sound { get; }
        public IMovableObjectParameters Parameters { get; }
        public bool Active { get; set; } = true;


        public override void update()
        {
            if (!Active) return;
            if (moveDefiner.key(command.Left))
            {
                MoveLeft();
                PlayMoveSound();
            }
            else if (moveDefiner.key(command.Right))
            {
                MoveRight();
                PlayMoveSound();
            }
            ApplyGravity();
            ApplyBlocksCollisions();
            CheckIfUnderwater();
            CheckIfTouchesFluid(BlockType.Lava);
        }

        private void PlayMoveSound()
        {
            if (ActiveElements.GetActiveToppings(position).Any(s => Collide(s)))
            {
                Sound.PlaySound(SoundType.Walking);
            }
        }

        private void CheckIfTouchesFluid(BlockType lava)
        {
            if (ActiveElements.GetActiveFluids(position).FindAll(s => s.Id == lava).Any(s => Collide(s))) status.DealDamageFromLava();
        }

        public void CheckIfUnderwater()
        {
            foreach (var item in ActiveElements.GetActiveFluids(position))
            {
                if (Collide(item))
                {
                    if (!IsInWater)
                    {
                        Sound.PlaySound(SoundType.WaterEnter);
                        IsInWater = true;
                    }
                    WaterTicks++;
                    if (WaterTicks > 19)
                    {
                        status.DealBreathBuuble();
                        WaterTicks = 0;
                    }
                    return;
                }
            }
            if (IsInWater)
            {
                Sound.PlaySound(SoundType.WaterExit);
                IsInWater = false;
            }
            status.RestoreBreath();
        }

        private void ApplyBlocksCollisions()
        {
            foreach (var b in ActiveElements.GetActiveBlocks(position))
            {
                if (Collide(b))
                {
                    if (speed > 0)
                    {
                        TicksElapsed = 0;
                        speed = -speed;
                    }
                    else if (Collide(b.foliage) && TicksElapsed == Parameters.BlocksCollisionDelay)
                        move(roation.Up, Parameters.StandUpSpeed);
                }
            }
            if (TicksElapsed != Parameters.BlocksCollisionDelay) TicksElapsed++;
        }

        private void ApplyGravity()
        {
            var touchesFluid = ActiveElements.GetActiveFluids(position).Any(s => Collide(s));
            if (moveDefiner.key(command.Jump) && Grounded)
            {
                Grounded = false;

                speed = touchesFluid ? Parameters.WaterJumpSpeed : Parameters.MaxFallSpeed;
            }
            foreach (var block in ActiveElements.GetActiveToppings(position))
            {
                if (Collide(block) && TicksElapsed >= Parameters.BlocksCollisionDelay)
                {
                    Grounded = true;
                    if (speed < 0) speed = 0;
                    status.DealDamage(DistanceFalled);
                    DistanceFalled = 0;
                    break;
                }
            }
            move(roation.Up, speed);
            ChangeMoveSpeed(touchesFluid);

        }

        internal void DealAttackDamage(int power)
        {
            if (flip)
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
            status.Deal(power);
        }

        private void ChangeMoveSpeed(bool touchesWater)
        {
            if (speed < 0) DistanceFalled -= speed;
            if (touchesWater)
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
            foreach (var b in ActiveElements.GetActiveBlocks(position))
            {
                if (Collide(b))
                {
                    move(roation.Left, Parameters.moveSpeed);
                    OnWallHit?.Invoke(this, null);
                    break;
                }
            }
        }

        private void MoveLeft()
        {
            flip = true;
            move(roation.Left, Parameters.moveSpeed);
            foreach (var b in ActiveElements.GetActiveBlocks(position))
            {
                if (Collide(b))
                {
                    move(roation.Right, Parameters.moveSpeed);
                    OnWallHit?.Invoke(this, null);
                    break;
                }
            }
        }
    }
}