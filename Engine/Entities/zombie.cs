using Engine.Engine;
using Engine.Logic.models;
using Engine.PixBlocks_Implementations;
using Engine.Logic;
using Engine.Resources;

namespace Engine.Entities
{
    class Zombie : MovableObject
    {
        public Zombie(IActiveElements ActiveElements, IDrawer drawer, IPixSound sound,Parameters parameters) : base(ActiveElements, drawer, null, new PlayerStatus(null, parameters), sound, parameters)
        {
            size = 10;
            parameters.moveSpeed = 3;
            var logic = new Monster_AI(this);
            OnWallHit += logic.Zombie_OnWallHit;
            moveDefiner = logic;
        }
    }
}
