﻿namespace Engine.Engine.models
{
    // Token: 0x02000004 RID: 4
    public class Foliage : SpriteOverlay
    {
        // Token: 0x06000005 RID: 5 RVA: 0x000020D8 File Offset: 0x000002D8
        public Foliage(int x, int y, Block block) : base(x, y,  block.Engine)
        {
            size = block.size;
            image = 65;
            angle = 180.0;
            color = block.color;
            Block = block;
        }

        // Token: 0x17000002 RID: 2
        // (get) Token: 0x06000006 RID: 6 RVA: 0x00002150 File Offset: 0x00000350
        public Block Block { get; }
    }
}