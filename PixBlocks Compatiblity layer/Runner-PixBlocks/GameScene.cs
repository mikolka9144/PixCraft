
using Integration;
using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using PixBlocks.TopPanel.Components.Basic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace PixBlocks_Compatiblity_layer
{
    public class PixScene : IGameScene
    {

        public PixScene()
        {
            #region SetStolenSpriteList
            GameScenesSprites = GameScene.gameSceneStatic.GetType().GetField("gameObjects", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(GameScene.gameSceneStatic) as List<Sprite>;
            #endregion
            garbageCollector = new SpriteCollector(GameScenesSprites);
            GameScenesSprites.Insert(0, garbageCollector);
            SpriteRefresher = new SpriteRefresher(SpriteViews);
            GameScene.gameSceneStatic.add(SpriteRefresher);
        }
        public List<Sprite> GameScenesSprites { get; }

        private SpriteCollector garbageCollector;
        public Integration.Color background { get => null/*BRUH*/; set => GameScene.gameSceneStatic.background = value.Convert(); }
        public Dictionary<GenericSprite, PixSprite> SpriteViews { get; } = new Dictionary<GenericSprite, PixSprite>();
        internal SpriteRefresher SpriteRefresher { get; }
        public string GetInput(string v) => GameScene.gameSceneStatic.PythonCodeRunner.show(v);

        public void ShowErrorStatic(Exception ex)
        {
            ShowMessage($"A folowing exeption occurded:\n{ex.Message}\nPlease send me a screenshot of this messages ");
            MessageBox.Show($"Here is StackTrace:\n{ex.StackTrace}");
        }
        public void ShowError(Exception ex) => ShowErrorStatic(ex);
        public void start()
        {
            GameScene.gameSceneStatic.start();
        }
        private static void Show(string v)
        {
            CustomMessageBox.Show(v);
        }

        public bool key(string v)
        {
            return GameScene.gameSceneStatic.key(v);
        }

        public void add(GenericSprite sprite)
        {
            if (!SpriteViews.ContainsKey(sprite)) CreateSprite(sprite);
            GameScene.gameSceneStatic.add(SpriteViews[sprite]);
            sprite.IsInvisible = true;
            GameScenesSprites.Remove(SpriteRefresher);
            GameScenesSprites.Add(SpriteRefresher);
        }

        private void CreateSprite(GenericSprite sprite)
        {
            var spriteToAdd = new PixSprite(sprite.update);
            SpriteRefresher.CopyData(sprite, spriteToAdd);
            SpriteViews.Add(sprite, spriteToAdd);
        }

        public void remove(GenericSprite sprite)
        {
            if (!SpriteViews.ContainsKey(sprite)) return;
            GameScene.gameSceneStatic.remove(SpriteViews[sprite]);
            sprite.IsInvisible = false;
            garbageCollector.SpritesToRemove.Add(SpriteViews[sprite]);
            SpriteViews.Remove(sprite);
        }

        public void stop()
        {
            GameScene.gameSceneStatic.stop();
        }

        public void ShowMessage(string v)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => Show(v)));
        }
    }
    internal class SpriteCollector : Sprite
    {
        public SpriteCollector(List<Sprite> gameScenesSprites)
        {
            size = 0;
            GameScenesSprites = gameScenesSprites;
        }

        public List<Sprite> SpritesToRemove { get; } = new List<Sprite>();
        public List<Sprite> GameScenesSprites { get; }

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
