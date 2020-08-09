using Engine.Engine.models;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;
using System.Reflection;
using Vector = PixBlocks.PythonIron.Tools.Integration.Vector;

namespace Engine.Engine
{
    internal class Drawer : IDrawer
    {
        public List<Sprite> GameScenesSprites { get; }
        public IDrawerParameters Parameters { get; }

        private SpriteCollector garbageCollector;

        public Drawer(IDrawerParameters parameters)
        {
            #region SetStolenSpriteList
            GameScenesSprites = GameScene.gameSceneStatic.GetType().GetField("gameObjects", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameScene.gameSceneStatic) as List<Sprite>;
            #endregion
            garbageCollector = new SpriteCollector();
            GameScenesSprites.Insert(0,garbageCollector);
            Parameters = parameters;
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
        private void AddSpriteToGame(Sprite sprite)
        {
            if (!sprite.IsVisible)
            {
                GameScene.gameSceneStatic.add(sprite);
            }
        }

        public void remove(SpriteOverlay sprite)
        {
            GameScene.gameSceneStatic.remove(sprite);
            garbageCollector.SpritesToRemove.Add(sprite);
        }
    }

    internal class SpriteCollector : Sprite
    {
        public SpriteCollector()
        {
            #region SetStolenSpriteList
            GameScenesSprites = GameScene.gameSceneStatic.GetType().GetField("gameObjects", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameScene.gameSceneStatic) as List<Sprite>;
            #endregion
            size = 0;
        }

        public List<Sprite> SpritesToRemove { get; } = new List<Sprite>();
        public List<Sprite> GameScenesSprites { get; }

        public override void update()
        {
            foreach (var item in SpritesToRemove)
            {
                if(!item.IsVisible)GameScenesSprites.Remove(item);
            }
            SpritesToRemove.Clear();
        }
    }
}