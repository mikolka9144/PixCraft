using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Engine
{
    class Drawer:IDrawer
    {
        
        public void Draw(SpriteOverlay sprite)
        {

            var flag = sprite.X > Parameters.border.Left || sprite.X < -Parameters.border.Right ||
               sprite.Y > Parameters.border.Up || sprite.Y < -Parameters.border.Down;

            if (flag)
            {
                sprite.Sprite.IsVisible = false;
            }
            else
            {
                sprite.Sprite.position = new Vector(sprite.X, sprite.Y);
                bool flag2 = !sprite.Sprite.IsVisible;
                if (flag2)
                {
                    AddSpriteToGame(sprite);
                }
            }
        }

        // Token: 0x0600001A RID: 26 RVA: 0x000026D8 File Offset: 0x000008D8
        private void AddSpriteToGame(SpriteOverlay sprite)
        {
            if (!sprite.Sprite.IsVisible)
            {
                GameScene.gameSceneStatic.add(sprite.Sprite);
            }
        }
        public void remove(Sprite sprite)
        {
            GameScene.gameSceneStatic.remove(sprite);
        }
    }
}
