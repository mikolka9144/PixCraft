using Engine.Engine.models;
using Engine.Logic;
using Integration;
using System.Collections.Generic;

namespace Engine.Engine
{
    internal class Drawer : IDrawer
    {
        public List<GenericSprite> GameScenesSprites { get; }
        public IDrawerParameters Parameters { get; }
        public IGameScene GameScene { get; }

        public Drawer(IDrawerParameters parameters,IGameScene gameScene)
        {
            Parameters = parameters;
            GameScene = gameScene;
        }
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
        private void AddSpriteToGame(GenericSprite sprite)
        {
            if (!sprite.IsVisible)
            {
                GameScene.add(sprite);
            }
        }

        public void remove(GenericSprite sprite)
        {
            GameScene.remove(sprite);
            

        }
    }

    
}