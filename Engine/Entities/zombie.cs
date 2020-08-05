using Engine.Engine;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Logic;

namespace Engine.Entities
{
    class Zombie : MovableObject
    {
        public Zombie(IActiveElements ActiveElements, IDrawer drawer, IPixSound sound) : base(ActiveElements, drawer, null, new PlayerStatus(null), sound)
        {
            size = 10;
            moveDefiner = new Monster_AI(this);
        }
    }
}
