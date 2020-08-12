
using Integration;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.TopPanel.Components.Basic;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace PixBlocks_Compatiblity_layer
{
    public class PixScene : IGameScene
    {
        public List<Sprite> GameScenesSprites { get; }

        private SpriteCollector garbageCollector;

        public PixScene()
        {
            #region SetStolenSpriteList
            GameScenesSprites = GameScene.gameSceneStatic.GetType().GetField("gameObjects", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameScene.gameSceneStatic) as List<Sprite>;
            #endregion
            garbageCollector = new SpriteCollector();
            GameScenesSprites.Insert(0, garbageCollector);
        }
        public Integration.Color background { get; set; }

        public string GetInput(string v)
        {
            throw new NotImplementedException();
        }

        public void ShowError(Exception ex)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => Show(ex)));
        }

        public void start()
        {
            throw new NotImplementedException();
        }
        private void Show(Exception ex)
        {
            CustomMessageBox.Show($"A folowing exeption occurded:\n{ex.Message}\n{ex.StackTrace}\nPlease send me a screenshot of this message");
        }

        public bool key(string v)
        {
            throw new NotImplementedException();
        }

        public void add(GenericSprite sprite)
        {
            
        }

        public void remove(GenericSprite sprite)
        {

            garbageCollector.SpritesToRemove.Add(sprite);
        }
    }
    internal class SpriteCollector : Sprite
    {
        public SpriteCollector()
        {
            size = 0;
        }

        public List<GenericSprite> SpritesToRemove { get; } = new List<GenericSprite>();
        public List<GenericSprite> GameScenesSprites { get; }

        public override void update()
        {
            foreach (var item in SpritesToRemove)
            {
                if (!item.IsVisible) GameScenesSprites.Remove(item);
            }
            SpritesToRemove.Clear();
        }
    }
}
