﻿using Engine.Engine;
using Engine.Engine.models;
using Engine.GUI;
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
        private readonly IMover tileManager;
        private readonly IMoveDefiner moveDefiner;
        private readonly Parameters paramters;
        protected readonly PlayerStatus status;
        private bool Grounded;
        private PauseMenu settingsForm;
        private int TicksElapsed;
        private int speed;
        private int TicksElapsedForMove;
        private int DistanceFalled;

        public Movable_object(IActiveElements ActiveElements,IMover tileManager,IMoveDefiner moveDefiner,PointerController pointer,Parameters paramters,PlayerStatus status)
        {
            this.ActiveElements = ActiveElements;
            this.tileManager = tileManager;
            this.moveDefiner = moveDefiner;
            Pointer = pointer;
            this.paramters = paramters;
            this.status = status;
            speed = 0;
			Grounded = false;
			TicksElapsed = paramters.BlocksCollisionDelay;
			TicksElapsedForMove = paramters.MoveDelay;
			settingsForm = new PauseMenu(paramters);
		}

        public IActiveElements ActiveElements { get; }
        public PointerController Pointer { get; }

        public override void update()
        {
            if (moveDefiner.key(command.Left) && TicksElapsedForMove >= paramters.MoveDelay)
            {
                MoveLeft();
            }
            else if (moveDefiner.key(command.Right) && TicksElapsedForMove >= paramters.MoveDelay)
            {
                MoveRight();
            }
            ApplyGravity();
            ApplyBlocksCollisions();
            if (moveDefiner.key(command.Pause)) Pause();
            if (moveDefiner.key(command.OpenInventory)) status.OpenInventory();
            
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
                    else if (collide(b.foliage.Sprite) && TicksElapsed == paramters.BlocksCollisionDelay) tileManager.Move(roation.Down, 3);
                }
            }
            if (TicksElapsed != paramters.BlocksCollisionDelay) TicksElapsed++;
            if (TicksElapsedForMove != paramters.MoveDelay) TicksElapsedForMove++;
        }

        private void Pause()
        {
            settingsForm.ShowDialog();
        }

        private void ApplyGravity()
        {
            
            if (moveDefiner.key(command.Jump) && Grounded)
            {

                Grounded = false;
                speed = paramters.MaxFallSpeed;
            }
            foreach (var block in ActiveElements.ActiveToppings)
            {

                if (collide(block.Sprite) && TicksElapsed >= paramters.BlocksCollisionDelay)
                {
                    Grounded = true;
                    Pointer.LastFoliage = block;
                    if (speed < 0) speed = 0;
                    status.DealDamage(DistanceFalled);
                    DistanceFalled = 0;
                    break;
                }

            }
            tileManager.Move(roation.Down, speed);
            if (speed < 0) DistanceFalled -= speed;
            if (speed > -paramters.MaxFallSpeed) speed -= 1;
        }

        private void MoveRight()
        {
            flip = false;
            tileManager.Move(roation.Left, 5);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b.Sprite))
                {
                    tileManager.Move(roation.Right, paramters.moveSpeed);
                    break;
                }
            }
        }

        private void MoveLeft()
        {
            flip = true;
            tileManager.Move(roation.Right, paramters.moveSpeed);
            foreach (var b in ActiveElements.ActiveBlocks)
            {
                if (collide(b.Sprite))
                {
                    tileManager.Move(roation.Left, paramters.moveSpeed);
                    break;
                }
            }
        }
    }
}
