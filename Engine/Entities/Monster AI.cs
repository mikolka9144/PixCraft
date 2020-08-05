using Engine.Engine.models;
using Engine.Resources;

namespace Engine.Entities
{
    class Monster_AI : IMoveDefiner
    {
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
                    return Sprite.Position.X > 0;
                case command.Right:
                    return Sprite.Position.X <= 0;
                case command.Jump:
                    break;
            }
            return false;
        }
    }
}
