using Engine.Engine;
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
        private readonly ITileManager tileManager;
        private readonly IMoveDefiner moveDefiner;
        private readonly Parameters paramters;
        private bool Grounded;
        private PauseMenu settingsForm;
        private int speed;

        public Movable_object(IActiveElements ActiveElements,ITileManager tileManager,IMoveDefiner moveDefiner,PointerController pointer,Parameters paramters)
        {
            this.Engine = ActiveElements;
            this.tileManager = tileManager;
            this.moveDefiner = moveDefiner;
            Pointer = pointer;
            this.paramters = paramters;
            speed = 0;
			Grounded = false;
			settingsForm = new PauseMenu(paramters);
		}

        public IActiveElements Engine { get; }
        public PointerController Pointer { get; }

        public override void update()
		{
			if (moveDefiner.key(command.Left))
			{

				flip = true;
				tileManager.Move(roation.Right, paramters.moveSpeed);
				foreach (var b in Engine.ActiveBlocks)
				{
					if (collide(b.Sprite))
					{
						tileManager.Move(roation.Left, paramters.moveSpeed);
						break;
					}
				}
			}
			else if (moveDefiner.key(command.Right))
			{

				flip = false;
				tileManager.Move(roation.Left, 5);
				foreach (var b in Engine.ActiveBlocks)
				{
					if (collide(b.Sprite))
					{
						tileManager.Move(roation.Right, paramters.moveSpeed);
						break;
					}
				}
			}
			if (moveDefiner.key(command.Jump) && Grounded)
			{

				Grounded = false;
				speed = paramters.MaxFallSpeed;
			}
			foreach (var block in Engine.ActiveToppings)
			{

				if (collide(block.Sprite))
				{
					Grounded = true;
					Pointer.LastFoliage = block;
					if (speed < 0) speed = 0;
					break;
				}

			}
			tileManager.Move(roation.Down, speed);

			if (speed > -paramters.MaxFallSpeed) speed -= 1;

			foreach (var b in Engine.ActiveBlocks)
			{
				if (collide(b.Sprite))
				{
					if (speed > 0)
					{
						speed = -speed;
						tileManager.Move(roation.Up, 1);
					}
					if (collide(b.foliage.Sprite)) tileManager.Move(roation.Down, 3);
				}
			}
			if (moveDefiner.key(command.Pause))
			{
				settingsForm.ShowDialog();
			}
		}
	}
}
