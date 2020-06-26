using Engine.Engine;
using Engine.Engine.models;
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
        private bool Grounded;
        private int speed;

        public Movable_object(IActiveElements ActiveElements,ITileManager tileManager,IMoveDefiner moveDefiner,PointerController pointer)
        {
            this.Engine = ActiveElements;
            this.tileManager = tileManager;
            this.moveDefiner = moveDefiner;
            Pointer = pointer;
			speed = 0;
			Grounded = false;
		}

        public IActiveElements Engine { get; }
        public PointerController Pointer { get; }

        public override void update()
		{
			if (moveDefiner.key(command.Left))
			{

				flip = true;
				tileManager.Move(roation.Right, 5);
				foreach (var b in Engine.ActiveBlocks)
				{
					if (collide(b.Sprite))
					{
						tileManager.Move(roation.Left, 5);
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
						tileManager.Move(roation.Right, 5);
						break;
					}
				}
			}
			if (moveDefiner.key(command.Jump) && Grounded)
			{

				Grounded = false;
				speed = 6;
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

			if (speed > -6) speed -= 1;

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
		}
	}
}
