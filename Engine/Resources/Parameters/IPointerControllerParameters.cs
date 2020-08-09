using PixBlocks.PythonIron.Tools.Integration;

namespace Engine.Logic
{
    public interface IPointerControllerParameters
    {
        int BreakingRange { get; }
        int PointerRange { get; }
        Color RedColor { get; }
        int PointerStatusChangeDelay { get; }
        Color DefaultColor { get; }
    }
}