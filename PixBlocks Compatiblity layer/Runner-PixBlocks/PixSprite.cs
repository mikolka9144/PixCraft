using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace PixBlocks_Compatiblity_layer
{
    public class PixSprite:Sprite
    {
        public PixSprite(Action update)
        {
            Update = update;
        }

        public Action Update { get; }
        public override void update()
        {
            Update();
        }
    }
}