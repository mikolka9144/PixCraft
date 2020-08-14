using Engine.Logic;

namespace Integration
{
    public class GenericSprite
    {
        public double size { get; set; } = 20;
        public virtual void update() { }
        public Vector2 position { get;  set; }
        public int image { get; set; } = 30;
        public Color color { get; set; } = new Color(15, 142, 255);
        public string text { get;  set; }
        public bool IsVisible { get;  set; }
        public double angle { get; set; }
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
