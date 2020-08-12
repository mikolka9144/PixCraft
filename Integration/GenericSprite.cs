using Engine.Logic;

namespace Integration
{
    public class GenericSprite
    {
        public double size { get; set; }
        public virtual void update() { }
        public Vector position { get;  set; }
        public int image { get;  set; }
        public Color color { get;  set; }
        public string text { get;  set; }
        public bool IsVisible { get; set; }

        public bool flip;
    }
}
