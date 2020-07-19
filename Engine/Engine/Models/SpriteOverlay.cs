using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class SpriteOverlay : Sprite
    {
        public SpriteOverlay(int x, int y, IDrawer engine)
        {
            X = x;
            Y = y;
            Engine = engine;
        }

        public IDrawer Engine { get; }

        public virtual void move(roation roation, int lenght)
        {
            SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        internal bool IsActiveBlock(int range)
        {
            return IsVisible && IsInRange(range);
        }

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

        public int X;
        public int Y;

        public bool IsInRange( int Range)
        {
            bool IsNotInRange = X > Range || X < -Range ||Y > Range || Y < -Range;
            return !IsNotInRange;
        }
    }
}