using Engine.Logic;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class PointerController:Sprite
    {
        private readonly IMoveDefiner moveDefiner;
        private readonly Parameters paramters;

        public PointerController(Pointer pointer,Engine engine,IMoveDefiner moveDefiner,Parameters paramters)
        {
            size = 0;
            point = pointer;
            Engine = engine;
            this.moveDefiner = moveDefiner;
            this.paramters = paramters;
            engine.Sprites.Add(pointer);
        }
        public Pointer point { get; }
        public Engine Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
			bool IsNotInRange = point.X > paramters.breakingRange || point.X < -paramters.breakingRange ||
				point.Y > paramters.breakingRange || point.Y < -paramters.breakingRange;

			if (moveDefiner.key(command.cameraCast))
			{
				point.X = LastFoliage.Block.X;
				point.Y = LastFoliage.Block.Y + 19;
			}
			else if (moveDefiner.key(command.cameraLeft)) point.Move(roation.Left, 20);
			else if (moveDefiner.key(command.cameraRight)) point.Move(roation.Right, 20);
			else if (moveDefiner.key(command.cameraUp)) point.Move(roation.Up, 20);
			else if (moveDefiner.key(command.cameraDown)) point.Move(roation.Down, 20);
			else if (moveDefiner.key(command.BreakBlock) && !IsNotInRange)
			{
				foreach (var b in Engine.ActiveBlocks)
				{
					
					if (this.point.Sprite.collide(b.Sprite))
					{
                        Engine.RemoveTile(b);
						break;
					}
				}
			}
			else if (moveDefiner.key(command.PlaceBlock) && !IsNotInRange) 
			{
				foreach (var b in Engine.ActiveBlocks)
				{
					if (point.Sprite.collide(b.Sprite)) return;
				}
				Engine.AddBlockTile(point.X, point.Y, BlockType.Dirt,20, true); 
			}
			if (IsNotInRange)
            {
				point.Sprite.image = 55;
            }
            else
            {
				point.Sprite.image = 56;
			}
		}
    }
}