using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    // Token: 0x02000005 RID: 5
    public class SpriteOverlay
    {
        // Token: 0x06000007 RID: 7 RVA: 0x00002158 File Offset: 0x00000358
        public SpriteOverlay(Sprite sprite, int x, int y, BlockType Id, IDrawer engine, IIdProcessor processor, Parameters parameters)
        {
            this.Sprite = sprite;
            this.X = x;
            this.Y = y;
            this.Id = Id;
            Engine = engine;
            this.parameters = parameters;

            if (processor != null) processor.ProcessSprite(this);
        }

        public Sprite Sprite { get; }
        public BlockType Id { get; }
        public IDrawer Engine { get; }

        // Token: 0x0600000C RID: 12 RVA: 0x000021C7 File Offset: 0x000003C7
        public virtual void Move(roation roation, int lenght)
        {
            this.SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        internal bool IsActiveBlock()
        {
            var IsNotInRange = X > parameters.hitboxArea.Right || X < -parameters.hitboxArea.Left
                || Y > parameters.hitboxArea.Up || Y < -parameters.hitboxArea.Down;
            return Sprite.IsVisible && !IsNotInRange;
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

        private readonly Parameters parameters;
    }
}