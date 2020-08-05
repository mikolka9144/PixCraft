﻿using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Engine.models
{
    public class SpriteOverlay : Sprite
    {
        public SpriteOverlay(int x, int y, IDrawer engine)
        {
            Position = new Positon(x, y);
            Engine = engine;
        }

        public IDrawer Engine { get; }

        public virtual void move(roation roation, int lenght)
        {
            SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        internal bool IsActiveBlock(int range, Positon offset)
        {
            return IsVisible && IsInRange(range,offset);
        }

        protected void SetPosition(roation roation, int lenght)
        {
            switch (roation)
            {
                case roation.Up:
                    Position.Y += lenght;
                    break;

                case roation.Left:
                    Position.X -= lenght;
                    break;

                case roation.Right:
                    Position.X += lenght;
                    break;

                case roation.Down:
                    Position.Y -= lenght;
                    break;
            }
        }

        public Positon Position { get; private set; }
        public bool IsInRange( int Range,Positon offset)
        {
            bool IsNotInRange = Position.X > Range+offset.X || Position.X < -Range+ offset.X || Position.Y > Range+ offset.Y || Position.Y < -Range+ offset.Y;
            return !IsNotInRange;
        }
        public bool IsInRange(int Range) => IsInRange(Range, new Positon(0, 0));
    }
}