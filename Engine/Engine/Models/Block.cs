using Engine.Resources;
using System;

namespace Engine.Engine.models
{
    [Serializable]
    public class Block : SpriteOverlay
    {
        public Block(int x, int y, BlockType Id, IDrawer engine, IIdProcessor processor) : base(x, y, engine)
        {
            image = 63;
            size = Parameters.BlockSize;
            foliage = new Foliage(x, y + (int)size / 3, this);

            processor.ProcessSprite(this, Id);
            processor.ProcessSprite(foliage, Id);
            this.Id = Id;
        }

        public Foliage foliage { get; private set; }
        public BlockType Id { get; }
    }
}