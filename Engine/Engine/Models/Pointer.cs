using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    // Token: 0x02000007 RID: 7
    public class Pointer : SpriteOverlay
    {
        // Token: 0x0600001C RID: 28 RVA: 0x00002818 File Offset: 0x00000A18
        public Pointer(Engine engine) : base(new Sprite(), 0, 0, -2, engine)
        {
            base.Sprite.size = 5.0;
            base.Sprite.image = 56;
        }

        // Token: 0x17000007 RID: 7
        // (get) Token: 0x0600001D RID: 29 RVA: 0x0000284E File Offset: 0x00000A4E
        // (set) Token: 0x0600001E RID: 30 RVA: 0x00002856 File Offset: 0x00000A56
        public bool Active { get; private set; }

        // Token: 0x0600001F RID: 31 RVA: 0x0000285F File Offset: 0x00000A5F
        public override void Move(double roation, double lenght)
        {
            base.Move(roation, lenght);
            this.Active = base.Sprite.IsVisible;
        }

    }
}