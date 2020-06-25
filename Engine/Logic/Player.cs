using Engine;
using Engine.Engine;
using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.Views.GameControllerView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    class Player:Sprite
    {
        private int speed;

        public Player(Engine.Engine.Engine engine,PointerController pointer,GameScene scene)
        {
            position = new Vector(0, 0);
			game = scene;
            size = 10;
            speed = 0;
            image = 0;
            Grounded = false;
            Engine = engine;
            Pointer = pointer;
        }
        public override void update()
        {
			if (game.key("a"))
            {

				flip = true;
				Engine.Move(roation.Right, 5);
                foreach (var b in Engine.ActiveBlocks)
                {
					if (collide(b.Sprite))
					{
						Engine.Move(roation.Left, 5);
						break;
					}
				} 
            }
			else if (game.key("d"))
            {

				flip = false;
				Engine.Move(roation.Left, 5);
				foreach (var b in Engine.ActiveBlocks)
				{
					if (collide(b.Sprite))
					{
						Engine.Move(roation.Right, 5);
						break;
					}
				}
			}
			if (game.key("space") && Grounded)
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
			Engine.Move(roation.Down, speed);

			if (speed > -6) speed -=1;

			foreach (var b in Engine.ActiveBlocks)
			{
				if (collide(b.Sprite)) 
				{
					if (speed > 0) 
					{
						speed = -speed;
						Engine.Move(roation.Up, 1); 
					}
					if (collide(b.foliage.Sprite)) Engine.Move(roation.Down, 3); 
				}
			}
		}

        private bool Grounded;

        public Engine.Engine.Engine Engine { get; }
        public PointerController Pointer { get; }
        public GameScene game { get; }
    }
}
