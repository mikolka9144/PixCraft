using Engine.Logic;

namespace Integration
{
    public class GenericSprite
    {
        public double size { get; set; } = 20;
        public virtual void update() { }
        public Vector2 position { get;  set; }
        public int image { get; set; } = 30;
        public Color color { get; set; } = new Color(0, 0, 0);
        public string text { get;  set; }
        public bool IsVisible { get;  set; }
        public double angle { get; set; }
        public bool flip;
    }
}
