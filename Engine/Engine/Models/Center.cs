using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class Center : SpriteOverlay
    {
        public Center(IDrawer engine) : base(new Sprite(), 0, 0, engine)
        {
            Sprite.size = 0;
        }
    }
}