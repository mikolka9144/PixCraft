using Engine.Engine.models;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine
{
    internal class Drawer : IDrawer
    {
        public void Draw(SpriteOverlay sprite)
        {
            var IsNotInBorder = sprite.X > Parameters.border.Left || sprite.X < -Parameters.border.Right ||
               sprite.Y > Parameters.border.Up || sprite.Y < -Parameters.border.Down;

            if (IsNotInBorder)
            {
                sprite.IsVisible = false;
            }
            else
            {
                sprite.position = new Vector(sprite.X, sprite.Y);
                AddSpriteToGame(sprite);
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000026D8 File Offset: 0x000008D8
        private void AddSpriteToGame(SpriteOverlay sprite)
        {
            if (!sprite.IsVisible)
            {
                GameScene.gameSceneStatic.add(sprite);
            }
        }

        public void remove(Sprite sprite)
        {
            GameScene.gameSceneStatic.remove(sprite);
        }
    }
}