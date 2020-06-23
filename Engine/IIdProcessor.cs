using PixBlocks.PythonIron.Tools.Integration;

namespace BlockEngine
{
    public interface IIdProcessor
    {
        void ProcessSprite(SpriteOverlay overlay);
    }
    public class BlockIdProcessor : IIdProcessor
    {
        public void ProcessSprite(SpriteOverlay overlay)
        {
            switch (overlay.Id)
            {
                case 1:
                    overlay.Sprite.color = new Color(100, 200, 50);
                    break;
                case 2:
                    overlay.Sprite.color = new Color(200, 100, 50);
                    break;
            }
        }
    }
}