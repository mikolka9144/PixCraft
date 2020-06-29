using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class Center : SpriteOverlay
    {
        public Center(Engine engine,Parameters parameters) : base(new Sprite(), 0, 0, BlockType.None, engine,null,parameters)
        {
            Sprite.size = 0;
        }
    }
}