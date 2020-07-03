using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    // Token: 0x02000007 RID: 7
    public class Pointer : SpriteOverlay
    {
        // Token: 0x0600001C RID: 28 RVA: 0x00002818 File Offset: 0x00000A18
        public Pointer(IDrawer engine) : base(new Sprite(), 0, 0, engine)
        {
            base.Sprite.size = 5.0;
            base.Sprite.image = 56;
        }

    }
}