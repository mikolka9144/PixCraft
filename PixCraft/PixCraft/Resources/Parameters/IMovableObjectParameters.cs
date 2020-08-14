using Integration;

namespace Engine.Logic
{
    public interface IMovableObjectParameters
    {
        int BlocksCollisionDelay { get; }
        int MoveDelay { get; }
        Color RedColor { get; }
        Color DefaultColor { get; }
        int StandUpSpeed { get; }
        int WaterJumpSpeed { get; }
        int MaxFallSpeed { get; }
        int moveSpeed { get; }
        int MaxWaterFallSpeed { get; }
    }
}