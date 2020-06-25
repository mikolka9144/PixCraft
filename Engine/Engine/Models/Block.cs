using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    // Token: 0x02000003 RID: 3
    public class Block : SpriteOverlay
    {
        // Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
        public Block(double x, double y, int Id, int size, IDrawer engine,IIdProcessor processor) : base(new Sprite(), x, y, Id, engine)
        {
            processor.ProcessSprite(this);
            Sprite.image = 63;
            Sprite.size = size;
            foliage = new Foliage(x, y + size / 3, Id, this);
        }

        public Foliage foliage { get; private set; }
    }
}