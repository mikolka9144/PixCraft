using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine
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
                case BlockType.Grass:
                    overlay.Sprite.color = new Color(100, 200, 50);
                    break;
                case BlockType.Dirt:
                    overlay.Sprite.color = new Color(200, 100, 50);
                    break;
                case BlockType.Stone:
                    overlay.Sprite.color = new Color(156, 159, 161);
                    break;
                case BlockType.Wood:
                    overlay.Sprite.color = new Color(153, 51, 0);
                    break;
                case BlockType.Leaves:
                    overlay.Sprite.color = new Color(102, 153, 51);
                    break;
            }
        }
    }
    public enum BlockType
    {
        None,
        Grass,
        Dirt,
        Stone,
        Wood,
        Leaves
    }
}