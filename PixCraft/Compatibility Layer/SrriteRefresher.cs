using Integration;
using PixBlocks.PythonIron.Tools.Integration;
using System.Collections.Generic;
using Color = PixBlocks.PythonIron.Tools.Integration.Color;

namespace PixBlocks_Compatiblity_layer
{
    internal class SpriteRefresher : Sprite
    {
        private Dictionary<GenericSprite, PixSprite> spriteViews;

        public SpriteRefresher(Dictionary<GenericSprite, PixSprite> spriteViews)
        {
            this.spriteViews = spriteViews;
            size = 0;
        }
        public override void update()
        {
            foreach (var item in spriteViews)
            {
                CopyData(item.Key,item.Value);
            }
        }

        public void CopyData(GenericSprite Key, Sprite Value)
        {
            var source = Key;
            Value.image = source.image;
            Value.text = source.text;
            Value.size = source.size;
            Value.color = new Color(source.color.r, source.color.g, source.color.b);
            Value.flip = source.flip;
            Value.position = new Vector(source.position.x, source.position.y);
            Value.angle = source.angle;
        }
    }
}