using Engine.Logic;

namespace Integration
{
    public class GenericSprite
    {
        public GenericSprite(bool IsDestroyAble = true)
        {
            this.IsDestroyAble = IsDestroyAble;
        }
        public double size { get; set; } 
        public virtual void update() { }
        public Vector2 position { get; set; } = new Vector2(0, 0);
        public int image { get; set; } 
        public Color color { get; set; } = new Color(15, 142, 255);
        public string text { get;  set; }
        public bool IsInvisible { get;  set; }
        public double angle { get; set; }
        public bool IsDestroyAble { get; }

        public bool flip;
        public bool Collide(GenericSprite sprite, double hitbox)
        {

            return CollideSystem.collide(position, size, sprite.position, hitbox);
        }
        public bool Collide(GenericSprite sprite)
        {
            return CollideSystem.collide(sprite,this);
        }
    }
}
