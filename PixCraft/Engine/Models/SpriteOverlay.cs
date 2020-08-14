using Engine.Logic;
using Integration;
using System;

namespace Engine.Engine.models
{
    public class SpriteOverlay : GenericSprite
    {
        public SpriteOverlay(int x, int y, IDrawer engine)
        {
            position = new Vector2(x, y);
            Engine = engine;
        }

        public IDrawer Engine { get; }

        public virtual void move(roation roation, int lenght)
        {
            SetPosition(roation, lenght);
            Engine.Draw(this);
        }

        protected void SetPosition(roation roation, int lenght)
        {
            switch (roation)
            {
                case roation.Up:
                    position.y += lenght;
                    break;

                case roation.Left:
                    position.x -= lenght;
                    break;

                case roation.Right:
                    position.x += lenght;
                    break;

                case roation.Down:
                    position.y -= lenght;
                    break;
            }
        }

        public bool IsActive { get; internal set; }
        

        public bool IsInRange( int Range,Vector2 offset)
        {
            bool IsNotInRange = position.x > Range+offset.x || position.x < -Range+ offset.x || position.y > Range+ offset.y || position.y < -Range+ offset.y;
            return !IsNotInRange;
        }
        public bool IsInRange(int Range) => IsInRange(Range, new Vector2(0, 0));
        
    }
}