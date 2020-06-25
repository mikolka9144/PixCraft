using PixBlocks.PythonIron.Tools.Integration;
using System;

namespace Engine.Engine.models
{
    // Token: 0x02000005 RID: 5
    public class SpriteOverlay
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002158 File Offset: 0x00000358
        public SpriteOverlay(Sprite sprite, int x, int y, int Id, IDrawer engine)
        {
            this.Sprite = sprite;
            this.X = x;
            this.Y = y;
            this.Id = Id;
            Engine = engine;
        }

        public Sprite Sprite { get; }
        public int Id { get; }
        public bool IsRendered = false;
        public IDrawer Engine { get; }

        // Token: 0x0600000C RID: 12 RVA: 0x000021C7 File Offset: 0x000003C7
        public virtual void Move(roation roation, int lenght)
        {
            this.SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        // Token: 0x0600000D RID: 13 RVA: 0x000021E0 File Offset: 0x000003E0
        protected void SetPosition(roation roation, int lenght)
        {
            switch (roation)
            {
                case roation.Up:
                    Y += lenght;
                    break;
                case roation.Left:
                    X -= lenght;
                    break;
                case roation.Right:
                    X += lenght;
                    break;
                case roation.Down:
                    Y -= lenght;
                    break;
                
            }
        }

        // Token: 0x04000004 RID: 4
        public int X;

        // Token: 0x04000005 RID: 5
        public int Y;
    }
}