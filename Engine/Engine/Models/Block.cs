using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.Engine.models
{
    [Serializable]
    public class Block : SpriteOverlay
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
        public Block(int x, int y, BlockType Id, int size, IDrawer engine,IIdProcessor processor,Parameters parameters) : base(new Sprite(), x, y, Id, engine,processor,parameters)
        {
            
            Sprite.image = 63;
            Sprite.size = size;
            foliage = new Foliage(x, y + size / 3, Id, this,processor,parameters);
        }

        public Foliage foliage { get; private set; }

    }
}