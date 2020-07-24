using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.GUI.Models
{
    public class PixControl : Sprite
    {
        public virtual void Hide()
        {
            GameScene.gameSceneStatic.remove(this);
        }

        public virtual void Show()
        {
            GameScene.gameSceneStatic.add(this);
        }
    }
}