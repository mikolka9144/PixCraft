using Engine.Engine.models;
using Engine.Resources;

namespace Engine.Entities
{
    class Monster_AI : IMoveDefiner
    {
        private bool Jump;

        public Monster_AI(SpriteOverlay sprite)
        {
            Sprite = sprite;
        }

        public SpriteOverlay Sprite { get; }

        public bool key(command command)
        {
            switch (command)
            {
                case command.Left:
                    if(Sprite.position.x > 0)
                    {
                        return true;
                    }
                    break;
                case command.Right:
                    if(Sprite.position.x < 0)
                    {
                        return true;
                    }
                    break;
                case command.Jump:
                    return jump();
            }
            return false;
        }

        private bool jump()
        {
            if(Jump)
            {
                Jump = false;
                return true;
            }
            return Jump;
        }

        internal void Zombie_OnWallHit(object sender, System.EventArgs e)
        {
            Jump = true;
        }
    }
}
