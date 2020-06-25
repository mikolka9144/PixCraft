using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine
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
                case 3:
                    overlay.Sprite.color = new Color(156, 159, 161);
                    break;
                case 4:
                    overlay.Sprite.color = new Color(153, 51, 0);
                    break;
                case 5:
                    overlay.Sprite.color = new Color(102, 153, 51);
                    break;
            }
        }
    }
}