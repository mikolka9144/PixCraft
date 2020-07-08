using Engine.Resources;
using System;

namespace Engine.Engine.models
{
    [Serializable]
    public class Block : SpriteOverlay
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
        public Block(int x, int y, BlockType Id, int size, IDrawer engine,IIdProcessor processor) : base(x, y,  engine)
        {
            
            image = 63;
            this.size = size;
            foliage = new Foliage(x, y + size / 3, this);

            processor.ProcessSprite(this,Id);
            processor.ProcessSprite(foliage,Id);
            this.Id = Id;
        }

        public Foliage foliage { get; private set; }
        public BlockType Id { get; }
    }
}