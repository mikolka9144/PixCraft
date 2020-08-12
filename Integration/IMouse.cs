using Engine.Logic;

namespace Integration
{
    public interface IMouse
    {
        Vector position { get; }
        bool pressed { get; }
    }
}