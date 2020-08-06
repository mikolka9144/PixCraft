using Engine.Engine.models;
using Engine.Logic;
using Engine.Resources;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine
{
    internal class Drawer : IDrawer
    {
        public void Draw(SpriteOverlay sprite)
        {
            var IsNotInBorder = sprite.Position.X > Parameters.border.Left || sprite.Position.X < -Parameters.border.Right ||
               sprite.Position.Y > Parameters.border.Up || sprite.Position.Y < -Parameters.border.Down;

            if (IsNotInBorder)
            {
                remove(sprite);
            }
            else
            {
                sprite.position = new Vector(sprite.Position.X, sprite.Position.Y);
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