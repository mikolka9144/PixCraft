using Engine.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Integration
{
    public static class CollideSystem
    {
        public static bool collide(Vector position1,double size1,Vector position2,double size2)
        {
            double num = size1 * 0.5 + size2 * 0.5;
            if (Math.Abs(position1.x - position2.x) > num || Math.Abs(position1.y - position2.y) > num)
            {
                return false;
            }
            if (Math.Sqrt((position1.x - position2.x) * (position1.x - position2.x) + (position1.y - position2.y) * (position1.y - position2.y)) < num)
            {
                return true;
            }
            return false;
        }

        public static bool collide(GenericSprite s1, GenericSprite s2) => collide(s1.position, s1.size, s2.position, s2.size);
    }
}
