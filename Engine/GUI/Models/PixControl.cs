using PixBlocks.PythonIron.Tools.Game;
using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.GUI.Models
{
    public class PixControl : Sprite
    {
        public Action<PixControl> OnClick;

        public virtual void Hide()
        {
            GameScene.gameSceneStatic.remove(this);
        }

        public virtual void Show()
        {
            GameScene.gameSceneStatic.add(this);
        }
        public override void update()
        {
            if (OnClick is null) return;
            if (collide(GameScene.gameSceneStatic.mouse.position) && GameScene.gameSceneStatic.mouse.pressed) OnClick(this);
        }

        private bool collide(Vector position)
        {
            double mouseSize = 10;
            double num = size * 0.5 + mouseSize * 0.5;
            if (Math.Abs(position.x - this.position.x) > num || Math.Abs(position.y - this.position.y) > num)
            {
                return false;
            }
            if (Math.Sqrt((position.x - this.position.x) * (position.x - this.position.x) + (position.y - this.position.y) * (position.y - this.position.y)) < num)
            {
                return true;
            }
            return false;
        }
    }
}