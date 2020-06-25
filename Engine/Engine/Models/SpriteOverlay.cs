using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.Engine.models
{
    // Token: 0x02000005 RID: 5
    public class SpriteOverlay
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002158 File Offset: 0x00000358
        public SpriteOverlay(Sprite sprite, double x, double y, int Id, IDrawer engine)
        {
            this.Sprite = sprite;
            this.X = (double)x;
            this.Y = (double)y;
            this.Id = Id;
            Engine = engine;
        }

        public Sprite Sprite { get; }
        public int Id { get; }
        public bool IsRendered = false;
        public IDrawer Engine { get; }

        // Token: 0x0600000C RID: 12 RVA: 0x000021C7 File Offset: 0x000003C7
        public virtual void Move(double roation, double lenght)
        {
            this.SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000021E0 File Offset: 0x000003E0
        protected void SetPosition(double roation, double lenght)
        {
            double num = 0.017453292519944;
            double num2 = -roation + 90.0;
            double num3 = lenght * Math.Sin(num * num2);
            double num4 = lenght * Math.Cos(num * num2);
            this.X += num3;
            this.Y += num4;
        }

        // Token: 0x04000004 RID: 4
        public double X;

        // Token: 0x04000005 RID: 5
        public double Y;
    }
}