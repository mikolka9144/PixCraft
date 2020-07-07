using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
using Engine.Resources;
using PixBlocks.Properties;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Logic
{
    abstract class Movable_object:Sprite
    {
        protected readonly IMover tileManager;
        protected readonly IMoveDefiner moveDefiner;
        protected readonly PlayerStatus status;
        protected event Action PostUpdate;
        protected event Action OnDamageDeal;

        private bool Grounded;
        private int TicksElapsed;
        private int speed;
        private int TicksElapsedForMove;
        private int DistanceFalled;

        public Movable_object(IActiveElements ActiveElements,IMover tileManager,IMoveDefiner moveDefiner,PointerController pointer,PlayerStatus status)
        {
            this.ActiveElements = ActiveElements;
            this.tileManager = tileManager;
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
            PostUpdate.Invoke();          
        }

        private void ApplyBlocksCollisions()
        {
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b.Sprite))
                {
                    if (speed > 0)
                    {
                        TicksElapsed = 0;
                        TicksElapsedForMove = 0;
                        speed = -speed;
                    }
                    else if (collide(b.foliage.Sprite) && TicksElapsed == Parameters.BlocksCollisionDelay) tileManager.Move(roation.Down, 3);
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

                if (collide(block.Sprite) && TicksElapsed >= Parameters.BlocksCollisionDelay)
                {
                    Grounded = true;
                    Pointer.LastFoliage = block;
                    if (speed < 0) speed = 0;
                    if(status.DealDamage(DistanceFalled)) OnDamageDeal.Invoke();
                    DistanceFalled = 0;
                    break;
                }

            }
            tileManager.Move(roation.Down, speed);
            if (speed < 0) DistanceFalled -= speed;
            if (speed > -Parameters.MaxFallSpeed) speed -= 1;
        }

        private void MoveRight()
        {
            flip = false;
            tileManager.Move(roation.Left,Parameters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b.Sprite))
                {
                    tileManager.Move(roation.Right,Parameters.moveSpeed);
                    break;
                }
            }
        }

        private void MoveLeft()
        {
            flip = true;
            tileManager.Move(roation.Right, Parameters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b.Sprite))
                {
                    tileManager.Move(roation.Left,Parameters.moveSpeed);
                    break;
                }
            }
        }
    }
}
