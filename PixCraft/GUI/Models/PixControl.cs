using Engine.Engine;
using Engine.Engine.models;
using Engine.Logic;
using Integration;
using System;

namespace Engine.GUI.Models
{
    public class PixControl : SpriteOverlay
    {
        public PixControl(IDrawer drawer,IMouse mouse):base(0,0,drawer)
        {
            GameScene = drawer;
            Mouse = mouse;
        }
        public Action<PixControl> OnClick;

        public IDrawer GameScene { get; }
        public IMouse Mouse { get; }

        public virtual void Hide()
        {
            GameScene.remove(this);
        }

        public virtual void Show()
        {
            GameScene.Draw(this);
        }
        public override void update()
        {
            if (OnClick is null) return;
            if (collide(Mouse.position) && Mouse.pressed) OnClick(this);
        }

        
    }
}