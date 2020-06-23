﻿using PixBlocks.PythonIron.Tools.Integration;

namespace BlockEngine
{
    // Token: 0x02000003 RID: 3
    public class Block : SpriteOverlay
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
        public Block(int x, int y, int Id, int size, Engine engine) : base(new Sprite(), x, y, Id, engine)
        {
            Sprite.image = 63;
            Sprite.size = size;
            foliage = new Foliage(x, y + size / 3, Id, this);
        }

        public Foliage foliage { get; private set; }
    }
}