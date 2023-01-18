using Engine.Logic;

namespace Integration
{
    public interface IMouse
    {
        Vector2 position { get; }
        bool pressed { get; }
    }
}