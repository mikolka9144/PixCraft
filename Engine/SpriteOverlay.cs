using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace BlockEngine
{
    // Token: 0x02000005 RID: 5
    public class SpriteOverlay
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002158 File Offset: 0x00000358
        public SpriteOverlay(Sprite sprite, int x, int y, int Id, Engine engine)
        {
            this.Sprite = sprite;
            this.X = (double)x;
            this.Y = (double)y;
            this.Id = Id;
            Engine = engine;
        }

        // Token: 0x17000003 RID: 3
        // (get) Token: 0x06000008 RID: 8 RVA: 0x00002188 File Offset: 0x00000388
        public Sprite Sprite { get; }

        // Token: 0x17000004 RID: 4
        // (get) Token: 0x06000009 RID: 9 RVA: 0x00002190 File Offset: 0x00000390
        public int Id { get; }

        public Engine Engine { get; }

        // Token: 0x17000005 RID: 5
        // (get) Token: 0x0600000A RID: 10 RVA: 0x00002198 File Offset: 0x00000398
        // (set) Token: 0x0600000B RID: 11 RVA: 0x000021B0 File Offset: 0x000003B0
        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
                this.Sprite.IsVisible = value;
            }
        }

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

        // Token: 0x04000006 RID: 6
        private bool isVisible = false;
    }
}