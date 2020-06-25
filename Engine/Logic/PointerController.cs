using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class PointerController:Sprite
    {
        public PointerController(GameScene game,Pointer pointer,Engine engine)
        {
            size = 0;
            this.game = game;
            point = pointer;
            Engine = engine;
			engine.Sprites.Add(pointer);
        }

        public GameScene game { get; }
        public Pointer point { get; }
        public Engine Engine { get; }
        public Foliage LastFoliage { get; set; }

        public override void update()
        {
			if (game.key("c"))
			{
				point.X = LastFoliage.Block.X;
				point.Y = LastFoliage.Block.Y + 19;
			}
			else if (game.key("left")) point.Move(-180, 20);
			else if (game.key("right")) point.Move(0, 20);
			else if (game.key("up")) point.Move(90, 20);
			else if (game.key("down")) point.Move(-90, 20);
			else if (game.key("m"))
			{
				foreach (var b in Engine.ActiveBlocks)
				{
					if (point.Sprite.collide(b.Sprite))
					{
						Engine.RemoveTile(b);
						break;
					}
				}
			}
			else if (game.key("n")) 
			{
				foreach (var b in Engine.ActiveBlocks)
				{
					if (point.Sprite.collide(b.Sprite)) return;
				}
				Engine.AddBlockTile(point.X, point.Y, 1,20, true); 
			}
		}
    }
}