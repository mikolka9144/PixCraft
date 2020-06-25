using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class Center : SpriteOverlay
    {
        public Center(Engine engine) : base(new Sprite(), 0, 0, -1, engine)
        {
            Sprite.size = 0;
        }
    }
}